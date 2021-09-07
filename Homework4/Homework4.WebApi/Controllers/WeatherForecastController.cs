using Homework4.BLL.Interfaces;
using Homework4.BLL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework4.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastService _weatherservice;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService weatherservice)
        {
            _logger = logger;
            _weatherservice = weatherservice;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return _weatherservice.Get().ToArray();
        }
    }
}
