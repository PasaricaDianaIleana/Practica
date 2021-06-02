using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Domains;

namespace WebApplication1.Business
{
    public interface IProductsRepository
    {
        List<Product> GetProducts();
        Product getProductById(int id);
       Product AddProduct(Product product);
        void UpdateProduct(Product product);
        Product DeleteProduct(int id);

    }
}
