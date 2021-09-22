using ControlWork1.DAL.Entities;
using ControlWork1.DAL.Interfaces;
using Homework5.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWork1.DAL.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {

        }

        public override Order Update(int id, Order entity)
        {
            var order = context.Orders.Find(id);

            order = entity;

            context.SaveChanges();

            return order;
        }
    }
}
