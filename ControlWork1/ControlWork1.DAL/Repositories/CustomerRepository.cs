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
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context)
        {

        }

        public override Customer Update(int id, Customer _customer)
        {
            var customer  = context.Customers.Find(id);

            customer.Name = _customer.Name;
            customer.Orders = _customer.Orders;
            
            context.SaveChanges();

            return customer;
        }
    }
}
