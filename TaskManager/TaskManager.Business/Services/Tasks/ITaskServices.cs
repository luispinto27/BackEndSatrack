using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = TaskManager.Data.Models.Task;

namespace TaskManager.Business.Services.Tasks
{
    public interface ITaskServices
    {
        List<Task> GetAllTasks();
        Task GetTaskById(int taskId);
        Task CreateTask(Task task);
        Task EditTask(Task task);
        Task DeleteTask(int taskId);


    }
}
