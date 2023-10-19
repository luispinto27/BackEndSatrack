using Microsoft.AspNetCore.Mvc;
using TaskManager.Business.Helpers.DTO;
using TaskManager.Business.Helpers.Response;
using TaskManager.Business.Services.Categories;
using TaskManager.Data.Models;

namespace TaskManager.API.Controllers.CategoryController
{
    [ApiController]
    [Route("api/category")]
    public class CategoryController: ControllerBase
    {
        private readonly ICategoryServices _categoryService;

        public CategoryController(ICategoryServices categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public List<Category> GetAllCategories()
        {
            return _categoryService.GetAllCategories();
        }

        [HttpGet("CategoryId")]
        public IActionResult GetCategoryById(int categoryId) 
        {
            var response = _categoryService.GetCategoryById(categoryId);

            return Ok(response);
        }

        [HttpPost]
        public IActionResult CreateCategory(CategoryDTO categoryCreated)
        {
            var response = _categoryService.CreateCategory(categoryCreated);

            return Ok(response);
        }

        [HttpPut]
        public IActionResult UpdateCategory(CategoryDTO categoryUpdated)
        {
            var response = _categoryService.UpdateCategory(categoryUpdated);

            return Ok(response);
        }

        [HttpDelete("CategoryId")]
        public IActionResult DeleteCategory(int categoryId)
        {
            var response = _categoryService.DeleteCategory(categoryId);

            return Ok(response);
        }

    }
}
