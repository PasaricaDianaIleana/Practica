using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Business;
using WebApplication1.Domains;
using WebApplication1.Models;

namespace WebApplication1.Controllers.CategoryController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repo;

        public CategoryController(ICategoryRepository repo)
        {
            _repo = repo;


        }
        [HttpGet]
        public CategoriesRepresentation GetAll()
        {
            var dbCategories = _repo.GetCategories();
            return new CategoriesRepresentation(dbCategories);
        }
        [HttpGet]
        [Route("{id}")]
        public  IActionResult GetCategoryById(int id)
        {
            var category = _repo.getCategoryById(id);
            return Ok(category);
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, Category category)
        {
            try
            {
                if (id != category.CategoryId)
                {
                    return BadRequest();
                }
            var data=  _repo.getCategoryById(id);
                if (data == null)
                {
                    return NotFound();
                }
                var updateCategory= _repo.UpdateCategory(category);
                return   Ok(updateCategory);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }
        [HttpPost]
        public IActionResult AddCategory( Category category)
        {
            try
            {
                if (category == null)
                {
                    return BadRequest("Category data is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Category data is invalid");
                }
                
                var NewCategory = _repo.Insert(category);

                return CreatedAtAction("GetAll", new { CategoryId = category.CategoryId }, category);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete("{id}")]
        public IActionResult  DeleteCategory(int id)
        {
            try
            {
                var categoryDelete = _repo.getCategoryById(id);
                if (categoryDelete == null)
                {
                    return NotFound();
                }
                var data = _repo.DeleteCategory(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
