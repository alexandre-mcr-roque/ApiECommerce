using ApiECommerce.Entities;
using ApiECommerce.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET api/Products?productType={productType}[&categoryId={categoryId}]
        [HttpGet]
        public async Task<IActionResult> GetProducts(string productType, int? categoryId = null)
        {
            IEnumerable<Product> products = null!;

            switch (productType.ToLower())
            {
                case "category":
                    if (categoryId != null)
                        products = await _productRepository.GetProductsByCategoryAsync(categoryId.Value);
                    break;
                case "popular":
                    products = await _productRepository.GetPopularProductsAsync();
                    break;
                case "bestseller":
                    products = await _productRepository.GetBestSellerProductsAsync();
                    break;
                default:
                    return BadRequest("Product type invalid.");
            }

            var productData = products.Select(p => new
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                ImageUrl = p.ImageUrl
            });

            return Ok(productData);
        }

        // GET api/Products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetails(int id)
        {
            var product = await _productRepository.GetProductDetailsAsync(id);
            if (product == null)
            {
                return NotFound($"Product with id={id} not found.");
            }

            var productData = new
            {

                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Details = product.Details,
                ImageUrl = product.ImageUrl
            };

            return Ok(productData);
        }
    }
}
