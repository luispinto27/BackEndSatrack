using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Data.Context;
using Task = TaskManager.Data.Models.Task;


namespace TaskManager.Data.Repositories.Tasks
{
    public class TaskRepository : ITaskRepository
    {
        public readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task CreateTask(Task task)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTask(int taskId)
        {
            throw new NotImplementedException();
        }

        public Task EditTask(Task task)
        {
            throw new NotImplementedException();
        }

        public List<Task> GetAllTasks()
        {
            throw new NotImplementedException();
        }

        public Task GetTaskById(int taskId)
        {
            throw new NotImplementedException();
        }
    }
}
