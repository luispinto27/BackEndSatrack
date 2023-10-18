using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Data.Repositories.Tasks;
using Task = TaskManager.Data.Models.Task;

namespace TaskManager.Business.Services.Tasks
{
    public class TaskServices : ITaskServices
    {
        private readonly ITaskRepository _taskRepository;

        public TaskServices(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
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
            List<Task> taskList = _taskRepository.GetAllTasks();

            if (taskList == null)
            {
                return new List<Task>();
            }

            return taskList;
        }

        public Task GetTaskById(int taskId)
        {
            throw new NotImplementedException();
        }
    }
}
