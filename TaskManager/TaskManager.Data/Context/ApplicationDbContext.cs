using Microsoft.EntityFrameworkCore;
using TaskManager.Data.Models;
using Task = TaskManager.Data.Models.Task;

namespace TaskManager.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Category> Category { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
    }
}
