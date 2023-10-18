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
        List<Task> GetAllTasks();
        Task GetTaskById(int taskId);
        Task CreateTask(Task task);
        Task EditTask(Task task);
        Task DeleteTask(int taskId);
    }
}
