using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Business;
using WebApplication1.Data;
using WebApplication1.Domains;
using WebApplication1.Models;

namespace WebApplication1.Controllers.ProductController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductsRepository _repository;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductController(IProductsRepository repository,IWebHostEnvironment hostEnvironment)
        {
            _repository = repository;
            _hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _repository.GetProducts();
            return Ok(products);
        }


        //[HttpPost]
        //public async Task<ActionResult> AddProduct([FromForm] Product product)
        //{
           
        //        if (product== null)
        //        {
        //            return BadRequest("Category data is null");
        //        }
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest("Category data is invalid");
        //        }
           
           
        //            var NewCategory = _repository.AddProduct(product);

        //        return CreatedAtAction("GetProducts", new { ProductId = product.ProductId }, product);

        //    }

        [HttpPost("Image")]

        public void PostMethod( Product product,  IFormFile file)
        {
            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "images", file.FileName);
            var streamImage = new FileStream(imagePath, FileMode.Create);
            file.CopyTo(streamImage);
            var prod = new Product
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                BasePrice = product.BasePrice,
                Image = imagePath,
                CategoryId = product.CategoryId,
            };
            _repository.AddProduct(prod);
        }

        //[HttpPost("AddImage")]
        //public void Post2([FromForm] ProductFormModel model)
        //{
        //    var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "images", model.File.FileName);
        //    var streamImage = new FileStream(imagePath, FileMode.Create);
        //    model.File.CopyTo(streamImage);
        //    var prod = new Product
        //    {
        //        Name = model.Name,
        //        Description = model.Description,
        //        Price = model.Price,
        //        BasePrice = model.BasePrice,
        //        Image = imagePath,
        //        CategoryId = model.CategoryId,
        //    };
        //    _repository.AddProduct(prod);
        //}

    }

}
       

    

       
    
