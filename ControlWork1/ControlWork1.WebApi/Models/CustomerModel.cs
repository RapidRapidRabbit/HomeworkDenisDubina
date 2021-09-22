using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControlWork1.WebApi.Models
{
    public class CustomerModel : IValidatableObject
    {
        
        public string Name { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (String.IsNullOrEmpty(Name))
                yield return new ValidationResult("Строка не должна быть пустой", new string[] { nameof(Name) });

            else if (char.IsLower(Name[0]))
                yield return new ValidationResult("Имя начинается не с заглавной буквы", new string[] { nameof(Name) });            
        }
    }
}
