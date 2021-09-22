using ControlWork1.BLL.DTO;
using ControlWork1.BLL.Interfaces;
using ControlWork1.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControlWork1.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {

        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService CustomerRepo;

        public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService)
        {
            _logger = logger;
            CustomerRepo = customerService;
        }

        [HttpGet("/GetCustomerById")]
        public IActionResult GetById([Required]int id)
        {
            CustomerDTO customer = CustomerRepo.GetCustomerById(id);

            if (customer != null)
                return new ObjectResult(customer);
            else
                ModelState.AddModelError("id", "Пользователь не найден");
                return ValidationProblem(ModelState);
        }

        [HttpGet("/GetAllCustomers")]
        public ActionResult<IEnumerable<CustomerDTO>> GetAll()
        {
            var customers = CustomerRepo.GetAllCustomers();

            if (customers != null)
                return new ObjectResult(customers);
            else
                return BadRequest();
        }

        [HttpPost("/AddCustomer/{Name}")]
        public IActionResult AddCustomer([FromRoute] CustomerModel model)
        {            
            CustomerRepo.AddCustomer(model.Name);
            return Ok();
        }

        [HttpPost("/UpdateCustomer/{id}/{Name}")]
        public IActionResult UpdateCustomer([Required] int id, [FromRoute] CustomerModel model)
        {
            var customer = CustomerRepo.GetCustomerById(id);

            if (customer != null)
            {
                CustomerRepo.UpdateCustomer(id, new CustomerDTO() { Id = id, Name = model.Name });
                return Ok();
            }

            ModelState.AddModelError("id", "Пользователь не найден");
            return ValidationProblem(ModelState);
        }

        [HttpDelete("/DeleteCustomer")]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = CustomerRepo.GetCustomerById(id);

            if (customer != null)
            {
                CustomerRepo.DeleteCustomer(id);
                return Ok();
            }

            ModelState.AddModelError("id", "Пользователь не найден");
            return ValidationProblem(ModelState);
        }
    }
}
