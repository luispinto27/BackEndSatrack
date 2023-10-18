using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Business.Helpers.DTO;
using TaskManager.Business.Helpers.Response;
using TaskManager.Data.Models;
using TaskManager.Data.Repositories.Categories;

namespace TaskManager.Business.Services.Categories
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryServices(ICategoryRepository categoryRepository)
        { 
            _categoryRepository = categoryRepository;
        }


        public CategoryResponse CreateCategory(CategoryDTO categoryCreated)
        {

            var taskNew = new Category
            {
                Description = categoryCreated.Description,
                Status = true
            };

            var result = _categoryRepository.CreateCategory(taskNew);

            if (result == null)
            {
                return new CategoryResponse
                {
                    NumberTask = 0,
                    DescriptionTask = string.Empty,
                    Message = "Ocurrio un error durante el almacenamiento de la tarea."
                };
            }
            else
            {
                return new CategoryResponse
                {
                    NumberTask = result.CategoryId,
                    DescriptionTask = result.Description,
                    Message = "Se ha creado correctamente la tarea"
                };
            }
            
        }

        public Category DeleteCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAllCategories()
        {
            List<Category> categoriesList = _categoryRepository.GetAllCategories();

            if (categoriesList == null)
            {
                return new List<Category>();
            }

            return categoriesList;
        }

        public CategoryResponse GetCategoryById(int categoryId)
        {
            Category category = _categoryRepository.GetCategoryById(categoryId);

            if (category == null)
            {
                return new CategoryResponse
                {
                    NumberTask = 0,
                    Message = "Lo sentimos la categoria a modificar no existe"
                };
            }
            else
            {
                return new CategoryResponse
                {
                    NumberTask = category.CategoryId,
                    DescriptionTask = category.Description,
                    Message = "La categoria buscada existe dentro de la aplicación"
                };
            }
        }

        public CategoryResponse UpdateCategory(CategoryDTO categoryUpdate)
        {
            Category currentCategory = _categoryRepository.GetCategoryById(categoryUpdate.CategoryId);

            if (currentCategory == null)
            {
                return new CategoryResponse
                {
                    NumberTask = 0,
                    DescriptionTask = string.Empty,
                    Message = "No se encontro la categoria buscada"
                };
            }

            var categoryUpdated = new Category
            {
                CategoryId = categoryUpdate.CategoryId,
                Description = categoryUpdate.Description,
                Status = categoryUpdate.Status
            };

            var result = _categoryRepository.UpdateCategory(categoryUpdated);

            if (result == null)
            {
                return new CategoryResponse
                {
                    NumberTask = 0,
                    DescriptionTask = string.Empty,
                    Message = "Ocurrio un error que no se esperaba"
                };
            }
            else
            {
                return new CategoryResponse
                {
                    NumberTask = result.CategoryId,
                    DescriptionTask = result.Description,
                    Message = "Categoria modificada correctamente"
                };
            }
        }
    }
}
