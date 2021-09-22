using ControlWork1.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5.DAL.EF
{
    public class AppDbContext : DbContext
    {

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies();                
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasMany(x => x.Orders)
                .WithOne(x => x.Customer)
                .HasForeignKey(x => x.CustomerId);

            modelBuilder.Entity<Product>()
                .HasMany(x=>x.Orders)                
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId);



            /*Product product1 = new Product { Id = 1, Name = "Banana", Description = "Tasty" };
            Product product2 = new Product { Id = 2, Name = "Apple", Description = "Super tasty" };
            Product product3 = new Product { Id = 3, Name = "Something", Description = "Not tasty" };

            Order order1 = new Order { Id = 1, CustomerId = 1, ProductId = 1,  };
            Order order2 = new Order { Id = 2, CustomerId = 2, ProductId = 2,  };
            Order order3 = new Order { Id = 3, CustomerId = 3, ProductId = 3,  };

            Customer customer1 = new Customer { Id = 1, Name = "Denis",  };
            Customer customer2 = new Customer { Id = 2, Name = "Vasya",  };
            Customer customer3 = new Customer { Id = 3, Name = "Dima",  };
            //customer1.Orders.Add(order1);
            //customer2.Orders.Add(order2);
            //customer3.Orders.Add(order3);
            //customer3.Orders.Add(order1);
            
            modelBuilder.Entity<Product>().HasData(product1, product2, product3);
            modelBuilder.Entity<Customer>().HasData(customer1, customer2, customer3);
            modelBuilder.Entity<Order>().HasData(order1, order2, order3);*/



            base.OnModelCreating(modelBuilder);
        }
    }
}
