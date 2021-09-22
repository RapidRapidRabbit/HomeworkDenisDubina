using ControlWork1.BLL.DTO;
using ControlWork1.BLL.Interfaces;
using ControlWork1.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControlWork1.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductService ProductRepo;

        public ProductsController(ILogger<ProductsController> logger, IProductService customerService)
        {
            _logger = logger;
            ProductRepo = customerService;
        }

        [HttpGet("/GetProductById")]
        public IActionResult GetById(int id)
        {
            var product = ProductRepo.GetProductById(id);

            if (product != null)
                return new ObjectResult(product);
            else
                ModelState.AddModelError("id", "Продукт не найден");
            return ValidationProblem(ModelState);
        }

        [HttpGet("/GetAllProducts")]
        public ActionResult<IEnumerable<ProductDTO>> GetAll()
        {
            var product = ProductRepo.GetAllProducts();

            if (product != null)
                return new ObjectResult(product);
            else
                ModelState.AddModelError("id", "Продукт не найден");
            return ValidationProblem(ModelState);
        }

        [HttpPost("/AddProduct/{Name}/{Description}")]
        public IActionResult AddProduct([FromRoute] ProductModel model)
        {
            ProductRepo.AddProduct(new ProductDTO() { Name = model.Name, Description = model.Description });
            return Ok();
        }

        [HttpPost("/UpdateProduct/{Name}/{Description}")]
        public IActionResult UpdateProduct([Required]int id, [FromRoute] ProductModel model)
        {
            var product = ProductRepo.GetProductById(id);

            if (product != null)
            {
                ProductRepo.UpdateProduct(id, new ProductDTO() { Id = id, Name = model.Name, Description = model.Description });
                return Ok();
            }

            ModelState.AddModelError("id", "Продукт не найден");
            return ValidationProblem(ModelState);
        }

        [HttpDelete("/DeleteProduct")]
        public IActionResult DeleteProduct(int id)
        {
            var product = ProductRepo.GetProductById(id);

            if (product != null)
            {
                ProductRepo.DeleteProduct(id);
                return Ok();
            }

            ModelState.AddModelError("id", "Продукт не найден");
            return ValidationProblem(ModelState);            
        }
    }
}
