using Homework_6_9.ModelBinders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Homework_6_9.Models.HomeTask_9_Models
{
   // [ModelBinder(BinderType = typeof(CompanyModelBinder))]
    public class Company
    {
        [BindNever]
        public int Id { get; set; }

        
        [BindRequired]
        public string Name { get; set; }

        [BindNever]
        public string Description { get; set; }

    }
}
