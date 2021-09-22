using ControlWork1.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWork1.BLL.Interfaces
{
    public interface ICustomerService
    {
        void AddCustomer(string name);
        IEnumerable<CustomerDTO> GetAllCustomers();
        CustomerDTO GetCustomerById(int id);
        CustomerDTO UpdateCustomer(int id, CustomerDTO customerDTO);
        void DeleteCustomer(int id);


    }
}
