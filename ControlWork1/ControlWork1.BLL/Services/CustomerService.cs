using ControlWork1.BLL.DTO;
using ControlWork1.BLL.Interfaces;
using ControlWork1.DAL.Entities;
using ControlWork1.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWork1.BLL.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository repo;

        public CustomerService(ICustomerRepository customerRepository)
        {
            repo = customerRepository;
        }

        public IEnumerable<CustomerDTO> GetAllCustomers()
        {
            var customers = repo.GetAll();

            List<CustomerDTO> customersDTO = new List<CustomerDTO>();

            foreach(var _customer in customers)
            {
                CustomerDTO customerDTO = new CustomerDTO()
                {
                    Id = _customer.Id,
                    Name = _customer.Name,
                    Orders = GetOrderDTOs(_customer.Orders).ToList(),
                };
                customersDTO.Add(customerDTO);
            }

            return customersDTO;
        }

        public CustomerDTO GetCustomerById(int id)
        {
            Customer customer = repo.Get(id);

            if (customer != null)
            {
                return new CustomerDTO
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    Orders = GetOrderDTOs(customer.Orders).ToList(),
                };
            }

            return null;
        }

        public void AddCustomer(string name)
        {
            repo.Add(new Customer { Name = name });
        }

        public CustomerDTO UpdateCustomer(int id, CustomerDTO customerDTO)
        {
            repo.Update(id,
                new Customer()
                {
                    Id = id,
                    Name = customerDTO.Name,
                    Orders = GetOrders(customerDTO.Orders).ToList(),
                }
                );

            return customerDTO;
        }

        public void DeleteCustomer(int id)
        {
            repo.Delete(id);
        }

        private static IEnumerable<OrderDTO> GetOrderDTOs(IEnumerable<Order> orders)
        {
            List<OrderDTO> ordersDTO = new List<OrderDTO>();

            if (orders != null)
            {
                foreach (var order in orders)
                {
                    OrderDTO orderDTO = new OrderDTO
                    {
                        Id = order.Id,
                        CustomerId = order.CustomerId,
                        ProductId = order.ProductId,
                    };
                    
                    ordersDTO.Add(orderDTO);
                }
            }
            return ordersDTO;
        }        
        private static IEnumerable<Order> GetOrders(IEnumerable<OrderDTO> ordersDTO)
        {
            List<Order> orders = new List<Order>();

            if (ordersDTO != null)
            {
                foreach (var _order in ordersDTO)
                {
                    Order order = new Order
                    {
                        Id = _order.Id,
                        CustomerId = _order.CustomerId,
                        ProductId = _order.ProductId,
                    };
                    
                    orders.Add(order);
                }
            }
            return orders;
        }
    }
}
