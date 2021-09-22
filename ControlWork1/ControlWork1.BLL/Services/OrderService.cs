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
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository repo;

        public OrderService(IOrderRepository orderRepository)
        {
            repo = orderRepository;
        }

        public void AddOrder(int customerId, int productId)
        {
            Order order = new Order() {

            CustomerId = customerId,
            ProductId = productId,

            };

            repo.Add(order);
        }

        public void DeleteOrder(int id)
        {
            repo.Delete(id);
        }

        public IEnumerable<OrderDTO> GetAllOrders()
        {
            var orders = repo.GetAll();

            List<OrderDTO> dtolist = new List<OrderDTO>();

            if (orders != null)
            {
                foreach (var order in orders)
                {
                    OrderDTO orderDTO = new OrderDTO()
                    {
                        Id = order.Id,
                        CustomerId = order.CustomerId,
                        ProductId = order.ProductId,
                    };
                    dtolist.Add(orderDTO);
                }
            }

            return dtolist;
        }

        public OrderDTO GetOrderById(int id)
        {
            var order = repo.Get(id);

            return new OrderDTO() {

            Id = order.Id,
            CustomerId = order.CustomerId,
            ProductId = order.ProductId,

            };
        }

        public OrderDTO UpdateOrder(int id, OrderDTO orderDTO)
        {
            repo.Update(id, new Order {
            
                Id = orderDTO.Id,
                CustomerId = orderDTO.CustomerId,
                ProductId = orderDTO.ProductId,
            });

            return orderDTO;
        }

        /*private static IEnumerable<Product> GetProducts (IEnumerable<ProductDTO> ProductDTOs)
        {
            List<Product> productList = new List<Product>();

            if (ProductDTOs != null)
            {
                foreach(var dto in ProductDTOs)
                {
                    productList.Add(new Product() {

                    Name = dto.Name,
                    Description = dto.Description,                    
                    });
                }
            }

            return productList;
        }*/
    }
}
