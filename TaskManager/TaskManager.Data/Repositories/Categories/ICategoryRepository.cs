using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Data.Models;

namespace TaskManager.Data.Repositories.Categories
{
    public interface ICategoryRepository
    {
        List<Category> GetAllCategories();
        Category GetCategoryById(int categoryId);
        Category CreateCategory(Category categoryCreated);
        Category UpdateCategory(Category categoryUpdate);
        Category DeleteCategory(int categoryId);
    }
}
