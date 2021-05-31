using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ProductRepresentation
    {
        public ProductRepresentation(int productId, string name, string description, decimal price, decimal basePrice, string image, int categoryId)
        {
            this.ProductId = productId;
            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.BasePrice = basePrice;
            this.Image=String.Format("{0}/{1}", "https://localhost:44395/api/produt", productId);
            this.CategoryId = categoryId;
        }
        [JsonProperty(PropertyName = "productId")]
        public int ProductId { get; set; }
        [JsonProperty(PropertyName="name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "price")]
        public decimal Price { get; set; }
        [JsonProperty(PropertyName = "basePrice ")]
        public decimal BasePrice { get; set; }
       [JsonProperty(PropertyName ="image")]
        public string Image { get; set; }
       [JsonProperty(PropertyName = "categoryId")]
        public int CategoryId { get; set; }



    }
}
