using MarketConnect.ProductAPI.DTOs;
using MarketConnect.ProductAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MarketConnect.ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            var categoriesDto = await _categoryService.GetCategories();

            if (categoriesDto == null)
            {
                return NotFound("Categories is not found");
            }


            return Ok(categoriesDto);
        }

        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategoriesProducts()
        {
            var categoriesDto = await _categoryService.GetCategoriesProducts();

            if (categoriesDto == null)
            {
                return NotFound("Categories is not found");
            }


            return Ok(categoriesDto);
        }

        [HttpGet("{id:int}", Name = "GetCategoryById")]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategoryById(int id)
        {
            var categoryDto = await _categoryService.GetCategoryById(id);

            if (categoryDto == null)
            {
                return NotFound("Category is not found");
            }


            return Ok(categoryDto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoryDTO categoryDto)
        {
            if (categoryDto == null)
            {
                return BadRequest("Invalid Data");
            }

            await _categoryService.AddCategory(categoryDto);

            return new CreatedAtRouteResult("GetCategoryById", new { id = categoryDto.CategoryId }, categoryDto);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] CategoryDTO categoryDto)
        {
            if (id != categoryDto.CategoryId)
            {
                return BadRequest();
            }

            if (categoryDto == null)
            {
                return NotFound();
            }

            await _categoryService.UpdateCategory(categoryDto);

            return Ok(categoryDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var categoryDto = _categoryService.GetCategoryById(id);

            if (categoryDto == null)
            {
                return NotFound();
            }

            await _categoryService.RemoveCategory(categoryDto.Result.CategoryId);

            return Ok(categoryDto);

        }

    }
}