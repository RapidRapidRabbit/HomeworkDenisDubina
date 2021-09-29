using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Homework_6_9.Models
{
    public class User :IValidatableObject
    {
        public string Name { get; set; }

        [Range(1, 99, ErrorMessage = "Возраст должен быть в промежутке от 1 до 99")]
        public int Age { get; set; }
        
        public string CardNumber { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var CardAttribute = new CreditCardAttribute();

            if (!CardAttribute.IsValid(CardNumber))
            {
                Log.Warning("CardNumber is not valid");
                yield return new ValidationResult("Тут надо прям реальный ввести :)", new string[] { nameof(CardNumber) });
            }

            if (!String.IsNullOrEmpty(Name))
            {
                if (Char.IsLower(Name[0]))
                {
                    Log.Warning("Name is not valid");
                    yield return new ValidationResult("Имя начинается не с заглавной буквы", new string[] { nameof(Name) });                   
                }

                

                for (int i = 0; i < Name.Length; i++)
                {
                    if (Char.IsNumber(Name[i]))
                    {
                        Log.Warning("Name is not valid");
                        yield return new ValidationResult("В имени не должно быть цифр", new string[] { nameof(Name) });
                        break;
                    }
                }
            }
            else
                Log.Warning("Name is not valid");
                yield return new ValidationResult("Строка не должна быть пустой", new string[] { nameof(Name) });
        }
    }
}
