using Homework_6_9.Models.HomeTask_9_Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework_6_9.ModelBinders
{
    public class CompanyModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if(context.Metadata.ModelType == typeof(Company))            
                return new BinderTypeModelBinder(typeof(CompanyModelBinder));
            

            return null;
        }
    }
}
