using ApiECommerce.Context;
using ApiECommerce.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ApiECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartItemsController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public ShoppingCartItemsController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET api/ShoppingCartItems/5
        [HttpGet("{userId}")]
        public async Task<IActionResult> Get(int userId)
        {
            var user = await _dbContext.Users.FindAsync(userId);
            if (user == null)
            {
                return NotFound($"User with id={userId} not found.");
            }

            var shoppingCartItems = await (from s in _dbContext.ShoppingCartItems.Where(s => s.ClientId == userId)
                                           join p in _dbContext.Products on s.ProductId equals p.Id
                                           select new
                                           {
                                               Id = s.Id,
                                               Price = s.UnitPrice,
                                               Total = s.Total,
                                               Quantity = s.Quantity,
                                               ProductId = p.Id,
                                               ProductName = p.Name,
                                               ImageUrl = p.ImageUrl
                                           }).ToListAsync();

            return Ok(shoppingCartItems);
        }

        // POST api/ShoppingCartItems
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ShoppingCartItem shoppingCartItem)
        {
            try
            {
                var shoppingCart = await _dbContext.ShoppingCartItems.FirstOrDefaultAsync(s =>
                                        s.ProductId == shoppingCartItem.ProductId
                                        && s.ClientId == shoppingCartItem.ClientId);

                if (shoppingCart != null)
                {
                    shoppingCart.Quantity += shoppingCartItem.Quantity;
                    shoppingCart.Total = shoppingCart.UnitPrice * shoppingCart.Quantity;
                }
                else
                {
                    var product = await _dbContext.Products.FindAsync(shoppingCartItem.ProductId);

                    var cart = new ShoppingCartItem
                    {
                        ClientId = shoppingCartItem.ClientId,
                        ProductId = shoppingCartItem.ProductId,
                        UnitPrice = shoppingCartItem.UnitPrice,
                        Quantity = shoppingCartItem.Quantity,
                        Total = shoppingCartItem.Total
                    };
                    _dbContext.ShoppingCartItems.Add(cart);
                }

                await _dbContext.SaveChangesAsync();
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "An error occurred while processing the request.");
            }
        }

        // GET api/ShoppingCartItems
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(int productId, string action)
        {
            var userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == userEmail);

            if (user == null)
            {
                return NotFound("User not found.");
            }
            var shoppingCartItem = await _dbContext.ShoppingCartItems.FirstOrDefaultAsync(s =>
                                    s.ClientId == user.Id && s.ProductId == productId);

            if (shoppingCartItem == null)
            {
                return NotFound("No items found in cart.");
            }

            switch (action.ToLower())
            {
                case "increase":
                    shoppingCartItem.Quantity++;
                    break;
                case "decrease":
                    if (shoppingCartItem.Quantity > 1)
                        shoppingCartItem.Quantity--;
                    else
                    {
                        _dbContext.ShoppingCartItems.Remove(shoppingCartItem);
                        await _dbContext.SaveChangesAsync();
                        return Ok($"Action: {action} successfully completed.");
                    }
                    break;
                case "delete":
                    _dbContext.ShoppingCartItems.Remove(shoppingCartItem);
                    await _dbContext.SaveChangesAsync();
                    return Ok($"Action: {action} successfully completed.");
                default:
                    return BadRequest("Invalid action. Valid actions : 'increase'  'decrease'   'delete'");
            }

            shoppingCartItem.Total = shoppingCartItem.UnitPrice * shoppingCartItem.Quantity;
            await _dbContext.SaveChangesAsync();
            return Ok($"Action: {action} successfully completed.");
        }
    }
}
