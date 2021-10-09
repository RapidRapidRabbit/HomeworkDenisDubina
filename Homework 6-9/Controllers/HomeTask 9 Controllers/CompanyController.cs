using Homework_6_9.Models.HomeTask_9_Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework_6_9.Controllers.HomeTask_9_Controllers
{
    [Route("api/HomeTask9Controllers/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        [HttpPut]
        public IActionResult AddCompany([FromQuery]Company company)
        {
            return Ok(company);
        }
    }
}
