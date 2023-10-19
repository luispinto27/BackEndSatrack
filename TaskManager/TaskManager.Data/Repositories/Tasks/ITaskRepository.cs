using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Data.Models;
using Task = TaskManager.Data.Models.Task;

namespace TaskManager.Data.Repositories.Tasks
{
    public interface ITaskRepository
    {
        List<Task> GetAllTask();
        Task GetTaskById(int categoryId);
        Task CreateTask(Task categoryCreated);
        Task UpdateTask(Task categoryUpdate);
        Task DeleteTask(Task categoryDelete);
    }
}
