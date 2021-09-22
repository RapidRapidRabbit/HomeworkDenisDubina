using ControlWork1.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlWork1.WebApi.Services
{
    public class OrderValidationService
    {
        private readonly IProductService productService;
        private readonly ICustomerService customerService;

        public OrderValidationService(IProductService productService, ICustomerService customerService)
        {
            this.productService = productService;
            this.customerService = customerService;
        }

        public bool ValidateModel(int productId, int customerId)
        {
            var customer = customerService.GetCustomerById(customerId);
            var product = productService.GetProductById(productId);

            if (customer == null || product == null)
                 return false;
            else
                return true;
        }
    }
}
