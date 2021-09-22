using ControlWork1.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWork1.BLL.Interfaces
{
    public interface IOrderService
    {
        void AddOrder(int id, int productid);
        IEnumerable<OrderDTO> GetAllOrders();
        OrderDTO GetOrderById(int id);
        OrderDTO UpdateOrder(int id, OrderDTO orderDTO);
        void DeleteOrder(int id);
    }
}
