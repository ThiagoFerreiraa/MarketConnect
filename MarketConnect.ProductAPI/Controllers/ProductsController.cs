using MarketConnect.ProductAPI.DTOs;
using MarketConnect.ProductAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MarketConnect.ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
        {
            var productDto = await _productService.GetProducts();

            if (productDto == null)
            {
                return NotFound();
            }

            return Ok(productDto);
        }

        //[HttpGet("{price:decimal}", Name = "GetProductsByPrice")]
        //public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductsByPrice(decimal price)
        //{
        //    var productDto = await _productService.GetProductsByPrice(price);

        //    if (productDto == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(productDto);
        //}

        [HttpGet("{id:int}", Name = "GetProductsById")]
        public async Task<ActionResult<ProductDTO>> GetProductById(int id)
        {
            var productDto = await _productService.GetProductById(id);

            if (productDto == null)
            {
                return NotFound();
            }

            return Ok(productDto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductDTO productDto)
        {
            if (productDto == null)
            {
                return BadRequest("Product is not valid.");
            }

            await _productService.AddProduct(productDto);

            return new CreatedAtRouteResult("GetProductsById", new { id = productDto.Id }, productDto);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ProductDTO productDto)
        {

            if (productDto == null)
            {
                return BadRequest("Data invalid");
            }

            await _productService.UpdateProduct(productDto);
            return Ok(productDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var productDto =  await _productService.GetProductById(id);

            if(productDto == null)
            {
                return NotFound();
            }

            await _productService.RemoveProduct(productDto.Id);

            return Ok(productDto);
        }
    }
}
