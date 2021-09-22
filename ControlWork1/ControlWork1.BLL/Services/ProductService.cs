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
    public class ProductService : IProductService
    {

        private readonly IProductRepository repo;

        public ProductService(IProductRepository Repository)
        {
            repo = Repository;
        }
        public void AddProduct(ProductDTO product)
        {
            repo.Add(new Product()
            {
                Name = product.Name,
                Description = product.Description,
            });
        }

        public void DeleteProduct(int id)
        {
            repo.Delete(id);
        }

        public IEnumerable<ProductDTO> GetAllProducts()
        {
            var productList = repo.GetAll();
            List<ProductDTO> dtoList = new List<ProductDTO>();

            foreach(var product in productList)
            {
                dtoList.Add(new ProductDTO()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                });
            }

            return dtoList;
        }

        public ProductDTO GetProductById(int id)
        {
            var product = repo.Get(id);

            if (product != null)
            {
                return new ProductDTO()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                };
            }

            return null;
        }

        public ProductDTO UpdateProduct(int id, ProductDTO productDTO)
        {
            repo.Update(id, new Product() {Name = productDTO.Name, Description = productDTO.Description });

            return productDTO;
        }
    }
}
