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
        Task GetTaskById(int taskId);
        Task CreateTask(Task taskCreated);
        Task UpdateTask(Task taskUpdate);
        Task DeleteTask(Task taskDelete);
        Task AsignedCategory(Task taskAsigned );
    }
}
