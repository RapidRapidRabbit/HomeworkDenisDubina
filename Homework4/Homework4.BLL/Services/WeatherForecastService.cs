using Homework4.BLL.Infrastucture;
using Homework4.BLL.Interfaces;
using Homework4.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4.BLL.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = WeatherSummaries.Summaries[rng.Next(WeatherSummaries.Summaries.Length)]
            });
        }
    }
}
