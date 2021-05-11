using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Business;
using WebApplication1.Domains;

namespace WebApplication1.Data
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly ShopContext _context;
        public CategoryRepository(ShopContext context)
        {
            _context = context;
        }

        public Category DeleteCategory(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.CategoryId == id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();

            }
            return null;
        }

        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category getCategoryById(int id)
        {
            return _context.Categories.FirstOrDefault(c => c.CategoryId == id);
        }

        public Category Insert(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();

            return category;
        }

        public Category UpdateCategory( Category category)
        {

            var findCategory = _context.Categories.FirstOrDefault(c => c.CategoryId ==category.CategoryId);

            if (findCategory != null)
            {
                findCategory.Name = category.Name;
                findCategory.Products = category.Products;

                _context.SaveChanges();

                return findCategory;
            }
            return null;

        

        }
    }
}
