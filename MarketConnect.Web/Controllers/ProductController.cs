using MarketConnect.Web.Models;
using MarketConnect.Web.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MarketConnect.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService; 

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> Index()
        {
            var result = await _productService.GetAllProducts();

            if (result == null) 
            {
                return View("Error");
            }

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            ViewBag.CategoryId = new SelectList(await _categoryService.GetAllCategories(), "CategoryId", "Name");
            return View();
        } 

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductViewModel pProductVM)
        {
            var result = await _productService.CreateProduct(pProductVM);

            if (result == null)
            {
                return View("Error");
            }

            return View();
        }
    }
}
