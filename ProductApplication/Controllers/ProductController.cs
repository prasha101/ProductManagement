using Microsoft.AspNetCore.Mvc;
using ProductApplication.Models;
using ProductApplication.Services;

namespace ProductApplication.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            _productService.CreateProduct(product);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(long id)
        {
            var product = _productService.GetProductById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(long id)
        {
            _productService.DeleteProduct(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(long id, [FromBody] Product product)
        {
            product.Id = id;
            var result = _productService.UpdateProduct(product);
            if(result == 0) return NotFound();
            return Ok();
        }

        [HttpPut("decrement-stock/{id}/{quantity}")]
        public IActionResult DecrementStock(long id, int quantity)
        {
            _productService.DecrementStock(id, quantity);
            return Ok();
        }

        [HttpPut("add-to-stock/{id}/{quantity}")]
        public IActionResult AddToStock(long id, int quantity)
        {
            _productService.AddToStock(id, quantity);
            return Ok();
        }
    }
}
