using System;
using Xunit;
using MVCApplication.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using Microsoft.AspNetCore.Mvc;


namespace TestProject
{
    public class HomeControllerTest
    {
        private readonly HomeController controller;
        private readonly ViewResult IndexView;

        public HomeControllerTest(){

            controller = new HomeController(Mock.Of<ILogger<HomeController>>());
            IndexView = controller.Index() as ViewResult;
        }


        [Fact]
        public void IndexReturnsViewResult()
        {            
            Assert.IsType<ViewResult>(IndexView);
        }

        [Fact]
        public void IndexViewBagMessageIsExpected()
        {            
            var actualvalue = IndexView.ViewData["Message"];

            Assert.Equal("Hello World!", actualvalue);
        }
    }
}
