using Homework3;
using Homework3.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using Xunit;

namespace EndPointsTests
{
    public class WeatherForecastControllerTests
    {
        private readonly WeatherForecastController controller;

        public WeatherForecastControllerTests()
        {
            controller = new WeatherForecastController(Mock.Of<ILogger<WeatherForecastController>>());
        }

        [Fact]
        public void Get_ShouldNotNull()
        {
            var actionResult = controller.Get();

            Assert.NotNull(actionResult);
        }

        [Fact]
        public void Get_Returns_ListOfWeatherForecast_With_5_Values()
        {
            var result = controller.Get();
            var collection = result as ICollection<WeatherForecast>;
            int actualvalue = collection.Count;
            int expectedvalue = 5;

            Assert.IsAssignableFrom<IEnumerable<WeatherForecast>>(result);
            Assert.Equal(expectedvalue, actualvalue);
        }

       
    }
}
