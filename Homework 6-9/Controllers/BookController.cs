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
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> logger;

        public BookController(ILogger<BookController> logger)
        {
            this.logger = logger;           
        }


        [HttpPost]
        [Route("/AddBook/{Name}/{Year}")]
        public IActionResult AddBook([FromRoute] Book book)
        {
            if (!String.IsNullOrEmpty(book.Name))
            {
                if (Char.IsLower(book.Name[0]))
                {
                    ModelState.AddModelError("Name", "Имя должно начинаться с заглавной буквы");
                    logger.LogWarning("Model is not valid");
                    return ValidationProblem(ModelState);
                }
            }
            else
            {
                ModelState.AddModelError("Name", "Пустая строка");
                logger.LogWarning("Model is not valid");

                return ValidationProblem(ModelState);

            }

            if (!String.IsNullOrEmpty(book.Name))
            {

                if (book.Year.Length != 4)
                {
                    ModelState.AddModelError("Year", "Только 4 цифры для года издания");
                    logger.LogWarning("Model is not valid");

                    return ValidationProblem(ModelState);
                }

                for (int i = 0; i < book.Year.Length; i++)
                {
                    if (!Char.IsNumber(book.Year[i]))
                    {
                        ModelState.AddModelError("Year", "Только цифры для года издания");
                        logger.LogWarning("Model is not valid");

                        return ValidationProblem(ModelState);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("Year", "Пустая строка");
                logger.LogWarning("Model is not valid");

                return ValidationProblem(ModelState);
            }

            return Ok(book);
        }
    }
}
