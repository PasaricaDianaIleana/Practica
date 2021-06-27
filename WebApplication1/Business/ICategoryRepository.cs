using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Domains;

namespace WebApplication1.Business
{
   public interface ICategoryRepository
    {
        List<Category> GetCategories();
        Category Insert(Category category);
        Category UpdateCategory(Category category);
          Category DeleteCategory(int id);
        public Category getCategoryById(int id);

       
    }
}
