using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Domains;

namespace WebApplication1.Models
{
    public class ProductsRepresentation
    {
        //public ProductsRepresentation(List<Product> products)
        //{
        //    this.Products = products.Select(x => new ProductRepresentation(x.ProductId, x.Name, x.Description, x.Price, x.BasePrice,x.Image,x.CategoryId)).ToList();
        //}

        //[JsonProperty(PropertyName ="products")]
        //public List<ProductRepresentation> Products { get; set; }
    }
}
