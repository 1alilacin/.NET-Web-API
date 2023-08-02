using APIHomework.DAL.Context;
using APIHomework.DAL.Entities;
using APIHomework.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIHomework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }

        [HttpGet]
        public IActionResult GetProduct()
        {
            var values = _productService.GetProducts();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            _productService.AddProduct(product);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var values = _productService.GetProductById(id);
            if (values == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(values);
            }

        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            _productService.DeleteProduct(id);

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            _productService.UpdateProduct(product);
            return Ok();
        }
    }
}
