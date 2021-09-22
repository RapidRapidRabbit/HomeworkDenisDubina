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
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {

        }

        public override Product Update(int id, Product entity)
        {
            Product product = context.Products.Find(id);

            product.Name = entity.Name;
            product.Description = entity.Description;

            context.SaveChanges();

            return product;
        }
    }
}
