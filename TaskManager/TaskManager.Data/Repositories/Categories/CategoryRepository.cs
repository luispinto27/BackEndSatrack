using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Data.Context;
using TaskManager.Data.Models;

namespace TaskManager.Data.Repositories.Categories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Category CreateCategory(Category categoryCreated)
        {
            try
            {
                _context.Category.Add(categoryCreated);
                _context.SaveChanges();

                return categoryCreated;
            }
            catch (Exception)
            {
                return new Category();
            }

        }

        public Category DeleteCategory(Category categoryDelete)
        {
            try
            {
                _context.Remove(categoryDelete);
                _context.SaveChanges();

                return categoryDelete;
            }
            catch (Exception)
            {
                return new Category();
            }
        }

        public List<Category> GetAllCategories()
        {
            try
            {
                return _context.Category.ToList();
            }
            catch (Exception)
            {
                return new List<Category>();
            }
            
        }

        public Category GetCategoryById(int categoryId)
        {
            try
            {
                return _context.Category.Where(w => w.CategoryId == categoryId).FirstOrDefault();
            }
            catch (Exception)
            {
                return new Category();
            }
        }

        public Category UpdateCategory(Category categoryUpdate)
        {
            try
            {
                var existingEntry = _context.ChangeTracker.Entries<Category>().FirstOrDefault(e => e.Entity.CategoryId == categoryUpdate.CategoryId);

                if (existingEntry != null)
                {
                    existingEntry.CurrentValues.SetValues(categoryUpdate);
                }
                else
                {
                    _context.Category.Attach(categoryUpdate);
                    _context.Entry(categoryUpdate).State = EntityState.Modified;
                }

                _context.SaveChanges();
                return categoryUpdate;

            }
            catch (Exception)
            {
                return new Category();
            }
        }
    }
}
