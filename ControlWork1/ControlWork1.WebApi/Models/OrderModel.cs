using ControlWork1.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ControlWork1.BLL.Services;
using ControlWork1.WebApi.Services;

namespace ControlWork1.WebApi.Models
{
    public class OrderModel : IValidatableObject
    {
        public int ProductId { get; set; }
        public int CustomerId { get; set; }    
        

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var service = validationContext.GetService(typeof(OrderValidationService)) as OrderValidationService;

            bool validationResult = service.ValidateModel(ProductId, CustomerId);
            
            if(!validationResult)
                yield return new ValidationResult("Продукт или пользователь не найден");
                
        }
    }
}
