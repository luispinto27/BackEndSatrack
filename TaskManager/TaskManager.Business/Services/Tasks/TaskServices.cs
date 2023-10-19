using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Business.Helpers.DTO;
using TaskManager.Business.Helpers.Response;
using TaskManager.Data.Models;
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

        public TaskResponse CreateTask(TaskDTO taskCreated)
        {

            var taskNew = new Task
            {
                Description = taskCreated.Description,
                DateCreated = DateTime.Now,
                IsCompleted = false,
                Category = taskCreated.CategoryId
            };

            var result = _taskRepository.CreateTask(taskNew);

            if (result == null)
            {
                return new TaskResponse
                {
                    NumberTask = 0,
                    DescriptionTask = string.Empty,
                    Message = "Ocurrio un error durante el almacenamiento de la tarea."
                };
            }
            else
            {
                return new TaskResponse
                {
                    NumberTask = result.TaskId,
                    DescriptionTask = result.Description,
                    Message = "Se ha creado correctamente la tarea"
                };
            }

        }

        public List<Task> GetAllTasks()
        {
            List<Task> taksList = _taskRepository.GetAllTask();

            if (taksList == null)
            {
                return new List<Task>();
            }

            return taksList;
        }

        public TaskResponse GetTaskById(int taskId)
        {
            Task task = _taskRepository.GetTaskById(taskId);

            if (task == null)
            {
                return new TaskResponse
                {
                    NumberTask = 0,
                    DescriptionTask = string.Empty,
                    Message = "Lo sentimos la tarea a modificar no existe"
                };
            }
            else
            {
                return new TaskResponse
                {
                    NumberTask = task.TaskId,
                    DescriptionTask = task.Description,
                    Message = "La tarea buscada existe dentro de la aplicación"
                };
            }
        }

        public TaskResponse UpdateTask(TaskDTO taskUpdate)
        {
            Task currentTask = _taskRepository.GetTaskById(taskUpdate.TaskId);

            if (currentTask == null)
            {
                return new TaskResponse
                {
                    NumberTask = 0,
                    DescriptionTask = string.Empty,
                    Message = "No se encontro la tarea buscada"
                };
            }

            var taskUpdated = new Task
            {
                TaskId = taskUpdate.TaskId,
                Description = taskUpdate.Description
            };

            var result = _taskRepository.UpdateTask(taskUpdated);

            if (result == null)
            {
                return new TaskResponse
                {
                    NumberTask = 0,
                    DescriptionTask = string.Empty,
                    Message = "Ocurrio un error que no se esperaba"
                };
            }
            else
            {
                return new TaskResponse
                {
                    NumberTask = result.TaskId,
                    DescriptionTask = result.Description,
                    Message = "Tarea modificada correctamente"
                };
            }
        }

        public TaskResponse DeleteTask(int taskId)
        {
            Task currentTask = _taskRepository.GetTaskById(taskId);

            if (currentTask == null)
            {
                return new TaskResponse
                {
                    NumberTask = 0,
                    DescriptionTask = string.Empty,
                    Message = "La tarea seleccionada no existe"
                };
            }

            var result = _taskRepository.DeleteTask(currentTask);

            return new TaskResponse
            {
                NumberTask = result.TaskId,
                DescriptionTask = result.Description,
                Message = "Tarea eliminada correctamente."
            };
        }
    }
}
