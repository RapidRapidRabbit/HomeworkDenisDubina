using Homework_6_9.Models.HomeTask_9_Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework_6_9.ModelBinders
{
    public class CompanyModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            Random random = new Random();


            var nameValue = bindingContext.ValueProvider.GetValue("Name");

            string name = nameValue.FirstValue;
            int id = random.Next();
            string description = "ModelBinder просто добавляет поле Id и этот текст";

            bindingContext.Result = ModelBindingResult.Success(new Company { Id = id, Name = name, Description = description });
            return Task.CompletedTask;
        }
    }
}
