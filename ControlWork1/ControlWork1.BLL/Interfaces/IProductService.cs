using ControlWork1.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWork1.BLL.Interfaces
{
    public interface IProductService
    {
        void AddProduct(ProductDTO product);
        IEnumerable<ProductDTO> GetAllProducts();
        ProductDTO GetProductById(int id);
        ProductDTO UpdateProduct(int id, ProductDTO productDTO);
        void DeleteProduct(int id);
    }
}
