using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Business.Helpers.DTO;
using TaskManager.Business.Helpers.Response;
using TaskManager.Data.Models;
using Task = TaskManager.Data.Models.Task;

namespace TaskManager.Business.Services.Tasks
{
    public interface ITaskServices
    {
        List<Task> GetAllTasks();
        TaskResponse GetTaskById(int taskId);
        TaskResponse CreateTask(TaskDTO taskCreated);
        TaskResponse UpdateTask(TaskDTO taskUpdated);
        TaskResponse DeleteTask(int taskId);
    }
}
