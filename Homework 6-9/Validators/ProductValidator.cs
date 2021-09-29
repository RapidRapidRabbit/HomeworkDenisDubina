using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Homework_6_9.Models;
using Serilog;

namespace Homework_6_9.Validators
{
    public class ProductValidator: AbstractValidator<Product>
    {
        public ProductValidator()
        {

            RuleFor(x => x.Name)
                .Custom((Name, context) =>
            {
                if (String.IsNullOrWhiteSpace(Name))
                {
                    Log.Warning("Product name is not valid");
                    context.AddFailure("Имя не должно быть пустым");
                }
            });

            RuleFor(x => x.Description)
                .Custom((Description, context) =>
                {
                    if (String.IsNullOrWhiteSpace(Description))
                    {
                        Log.Warning("Description is not valid");
                        context.AddFailure("Описание не должно быть пустым");
                    }
                });

            RuleFor(x => x.Price)
                .Custom((Price, context) =>
                {
                    if (Price <= 0)
                    {
                        Log.Warning("Price is not valid");
                        context.AddFailure("Цена должна быть больше 0");
                    }
                });
        }
    }
}
