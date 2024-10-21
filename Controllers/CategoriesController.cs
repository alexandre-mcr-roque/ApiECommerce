using ApiECommerce.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        // GET api/Categories
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _categoryRepository.GetCategoriesAsync();
            return Ok(categories);
        }
    }
}
