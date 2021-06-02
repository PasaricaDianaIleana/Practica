using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Business;
using WebApplication1.Domains;

namespace WebApplication1.Data
{
    public class ProductRepository : IProductsRepository
    {
        private readonly ShopContext _context;
        

        public ProductRepository(ShopContext context)
        {
            _context = context;
           
        }

        public Product  AddProduct(Product product)
        {
           
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public Product DeleteProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.ProductId == id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();

            }
            return null;
        }

        public Product getProductById(int id)
        {
            return _context.Products.FirstOrDefault(x => x.ProductId == id);
        }

        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public void UpdateProduct(Product product)
        {
            _context.Attach(product);
            _context.SaveChanges();
        }
    }
}
