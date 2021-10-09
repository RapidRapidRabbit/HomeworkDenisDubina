using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Homework_6_9.Models.HomeTask_8_9_Models
{
    public class PersonFilterModel
    {
       
        public int? Skip { get; set; }
        public int? Take { get; set; }
    }
}
