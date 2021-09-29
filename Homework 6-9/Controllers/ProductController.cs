using Homework_6_9.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework_6_9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> logger;

        public ProductController(ILogger<ProductController> logger)
        {
            this.logger = logger;
        }


        [HttpPost]
        [Route("/AddProduct/{Name}/{Price}/{Description}")]
        public IActionResult AddUser([FromRoute] Product product)
        {
            return Ok(product);
        }
    }
}
