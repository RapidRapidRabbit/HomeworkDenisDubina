using ControlWork1.BLL.DTO;
using ControlWork1.BLL.Interfaces;
using ControlWork1.BLL.Services;
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
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly IOrderService OrderRepo;

        public OrdersController(ILogger<OrdersController> logger, IOrderService orderService)
        {
            _logger = logger;
            OrderRepo = orderService;
        }

        [HttpGet("/GetOrderById")]
        public IActionResult GetById(int id)
        {
            var order = OrderRepo.GetOrderById(id);

            if (order != null)
                return new ObjectResult(order);
            else
                ModelState.AddModelError("id", "Заказ не найден");
            return ValidationProblem(ModelState);

        }

        [HttpGet("/GetAllOrders")]
        public ActionResult<IEnumerable<OrderDTO>> GetAll()
        {
            var order = OrderRepo.GetAllOrders();

            if (order != null)
                return new ObjectResult(order);
            else
                return BadRequest();
        }

        [HttpPost("/AddOrder/{CustomerId}/{ProductId}")]
        public IActionResult AddOrder([FromRoute] OrderModel model)
        {
            OrderRepo.AddOrder(model.CustomerId, model.ProductId);
            return Ok();
        }

        [HttpPost("/UpdateOrder/{Id}/{CustomerId}/{ProductId}")]
        public IActionResult UpdateOrder([Required] int Id, [FromRoute] OrderModel model)
        {
            var order = OrderRepo.GetOrderById(Id);

            if (order != null)
            {
                OrderRepo.UpdateOrder(Id, new OrderDTO() { Id = Id, CustomerId = model.CustomerId, ProductId = model.ProductId });
                return Ok();
            }

            ModelState.AddModelError("id", "Пользователь не найден");
            return ValidationProblem(ModelState);
        }

        [HttpDelete("/DeleteOrder")]
        public IActionResult DeleteCustomer([Required] int Id)
        {
            var order = OrderRepo.GetOrderById(Id);

            if (order != null)
            {
                OrderRepo.DeleteOrder(Id);
                return Ok();
            }

            ModelState.AddModelError("id", "Пользователь не найден");
            return ValidationProblem(ModelState);            
        }
    }
}
