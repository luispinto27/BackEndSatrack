using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Business.Helpers.DTO;
using TaskManager.Business.Helpers.Response;
using TaskManager.Data.Models;

namespace TaskManager.Business.Services.Categories
{
    public interface ICategoryServices
    {
        List<Category> GetAllCategories();
        CategoryResponse GetCategoryById(int categoryId);
        CategoryResponse CreateCategory(CategoryDTO categoryCreated);
        CategoryResponse UpdateCategory(CategoryDTO categoryUpdated);
        CategoryResponse DeleteCategory(int categoryId);
    }
}
