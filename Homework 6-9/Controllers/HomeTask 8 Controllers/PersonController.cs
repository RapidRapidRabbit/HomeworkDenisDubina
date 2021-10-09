using Homework_6_9.Models.HomeTask_8_9_Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework_6_9.Controllers
{
    [Route("api/HomeTask8Controllers/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly static List<Person> customers = new List<Person>()
       {
           new Person()
           {
               Id = 1,
               Name = "Denis",               
           },

           new Person()
           {
               Id = 2,
               Name = "Oleg",
           },

           new Person()
           {
               Id = 3,
               Name="Ekaterina",
           },

           new Person()
           {
               Id = 4,
               Name = "Valentina",
           },

           new Person()
           {
               Id = 5,
               Name = "Konstantin",
           },
       };

        [HttpGet]        
        public ActionResult<IEnumerable<Person>> GetAllPersons([FromQuery] PersonFilterModel filtermodel)
        {
            var result = customers;

            if (filtermodel != null)
            {
                if (filtermodel.Skip != null)
                {
                    result = result.Skip(filtermodel.Skip.Value).ToList();                    
                }

                if (filtermodel.Take != null)
                {
                    result = result.Take(filtermodel.Take.Value).ToList();
                }               
            }

            if (result.Count > 0)            
                return Ok(result);
            

            return NoContent();
        }
    }
}
