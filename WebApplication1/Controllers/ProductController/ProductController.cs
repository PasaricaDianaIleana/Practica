using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using WebApplication1.Business;
using WebApplication1.Domains;
using WebApplication1.Models;

namespace WebApplication1.Controllers.ProductController
{


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
        [Route("api/product")]
        public ProductsRepresentation GetProducts()
        {
            var products = _repository.GetProducts();
            return new ProductsRepresentation(products);
        }


        [HttpPost]
        [Route("api/product")]

        public IActionResult AddProduct([FromBody] Product product)
        {

            if (product == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }


            var NewCategory = _repository.AddProduct(product);

            return CreatedAtAction("GetProducts", new { ProductId = product.ProductId }, product);

        }

        [HttpPost]
        [Route("api/product/image/{id}")]
        public IActionResult PostMethod([FromRoute] int id, [FromForm] IFormFile file)
        {
            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "images", file.FileName);
            var streamImage = new FileStream(imagePath, FileMode.Create);
            file.CopyTo(streamImage);
          
            var product = _repository.getProductById(id);
            product.Image = file.FileName;
            _repository.UpdateProduct(product);
            return Ok();
        
        }

        [HttpDelete]
        [Route("api/product/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                var product = _repository.getProductById(id);
                if (product == null)
                {
                    return NotFound();
                }
                var delete = _repository.DeleteProduct(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("api/product/{id}/{fileName}")]
        public IActionResult GetImage(int id,string fileName)
        {
            string ext = Path.GetExtension(fileName).ToLower();
            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "images",fileName+ext);
            var image = System.IO.File.OpenRead(imagePath);
            return  File(image, "image/jpeg");
        }

        [HttpGet]
        [Route("api/produt/{id}")]
        public IActionResult GetImage([FromRoute] int id)
        {
            var data = _repository.getProductById(id);
            var file = data.Image;
            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "images", file);
            var image = System.IO.File.OpenRead(imagePath);
            return File(image, "image/jpeg");
        }
    }

}
       

    

       
    
