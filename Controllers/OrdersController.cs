using ApiECommerce.Context;
using ApiECommerce.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public OrdersController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/Orders/OrderDetails/5
        [HttpGet("[action]/{orderId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> OrderDetails(int orderId)
        {
            var orderDetails = await _dbContext.OrderDetails.AsNoTracking()
                                        .Where(d => d.OrderId == orderId)
                                        .Select(orderDetails => new
                                       {
                                           Id = orderDetails.Id,
                                           Quantity = orderDetails.Quantity,
                                           SubTotal = orderDetails.Total,
                                           ProductName = orderDetails.Product!.Name,
                                           productImage = orderDetails.Product.ImageUrl,
                                           productPrice = orderDetails.Product.Price,
                                       }).ToListAsync();

            if (orderDetails.Count == 0)
            {
                return NotFound("Order details not found.");
            }

            return Ok(orderDetails);
        }

        // GET api/Orders/OrdersFromUser/5
        [HttpGet("[action]/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> OrdersFromUser(int userId)
        {
            var orders = await _dbContext.Orders.AsNoTracking()
                                .Where(order => order.UserId == userId)
                                .OrderByDescending(order => order.OrderDate)
                                .Select(order => new
                                {
                                    Id = order.Id,
                                    OrderTotal = order.Total,
                                    OrderDate = order.OrderDate
                                }).ToListAsync();

            if (orders.Count == 0)
            {
                return NotFound("No orders from the user found.");
            }

            return Ok(orders);
        }

        // POST api/Orders
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] Order order)
        {
            order.OrderDate = DateTime.Now;

            var cartItems = await _dbContext.ShoppingCartItems
                .Where(c => c.ClientId == order.UserId)
                .ToListAsync();

            // Verify if there are items in the cart
            if (cartItems.Count == 0)
            {
                return NotFound("There are no items in the cart to create the order.");
            }

            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    _dbContext.Orders.Add(order);
                    await _dbContext.SaveChangesAsync();

                    foreach (var item in cartItems)
                    {
                        var orderDetails = new OrderDetail
                        {
                            Price = item.UnitPrice,
                            Total = item.Total,
                            Quantity = item.Quantity,
                            ProductId = item.ProductId,
                            OrderId = order.Id
                        };
                        _dbContext.OrderDetails.Add(orderDetails);
                    }

                    await _dbContext.SaveChangesAsync();
                    _dbContext.ShoppingCartItems.RemoveRange(cartItems);
                    await _dbContext.SaveChangesAsync();

                    await transaction.CommitAsync();

                    return Ok(new { OrderId = order.Id });
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    return BadRequest("An error occurred while processing the order.");
                }
            }
        }
    }
}
