using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Business.Helpers.DTO;
using TaskManager.Business.Helpers.Enum;
using TaskManager.Business.Helpers.Response;
using TaskManager.Data.Models;
using TaskManager.Data.Repositories.Categories;
using TaskManager.Data.Repositories.Tasks;
using Task = TaskManager.Data.Models.Task;

namespace TaskManager.Business.Services.Tasks
{
    public class TaskServices : ITaskServices
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ICategoryRepository _categoryRepository;

        public TaskServices(ITaskRepository taskRepository, ICategoryRepository categoryRepository)
        {
            _taskRepository = taskRepository;
            _categoryRepository = categoryRepository;   
        }

        public TaskResponse CreateTask(TaskDTO taskCreated)
        {

            var taskNew = new Task
            {
                Description = taskCreated.Description,
                DateCreated = taskCreated.DateCreated,
                IsCompleted = false,
                Category = _categoryRepository.GetCategoryByName(EnumCategoryDefault.CategoryDefault)
            };

            if (taskNew.Category == null)
            {
                return new TaskResponse
                {
                    NumberTask = 0, 
                    DescriptionTask = string.Empty,
                    Message = "No se encontro la categoria"
                };
            }

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
            Category currentCategory = _categoryRepository.GetCategoryById(taskUpdate.CategoryId);

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
                Description = taskUpdate.Description,
                DateCreated = taskUpdate.DateCreated,
                DateLimited = taskUpdate.DateLimited,
                Category = currentCategory
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

        public TaskResponse CompletedTask(int taskId)
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

            var taskCompleted = new Task
            {
                TaskId = taskId,
                Description = currentTask.Description,
                DateCreated = currentTask.DateCreated,
                DateLimited = currentTask.DateLimited,
                IsCompleted = true
            };

            var result = _taskRepository.UpdateTask(taskCompleted);

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
                    Message = "Tarea completada correctamente"
                };
            }
        }

        public TaskResponse AsignedCategory(int taskId, int categoryId)
        {

            Task currentTask = _taskRepository.GetTaskById(taskId);
            Category currentCategory = _categoryRepository.GetCategoryById(categoryId);

            if (currentTask == null)
            {
                return new TaskResponse
                {
                    NumberTask = 0,
                    DescriptionTask = string.Empty,
                    Message = "La tarea seleccionada no existe"
                };
            }

            var asignedCategory = new Task
            {
                TaskId = currentTask.TaskId,
                Description = currentTask.Description,
                DateCreated = currentTask.DateCreated,
                DateLimited = currentTask.DateLimited,
                IsCompleted = currentTask.IsCompleted,
                Category = currentCategory
            };

            var result = _taskRepository.AsignedCategory(asignedCategory);

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
                    Message = "Tarea completada correctamente"
                };
            }
        }

        public TaskResponse AsignedDateLimited(Task taskDateLimited)
        {

            Category currentCategory = _categoryRepository.GetCategoryById(taskDateLimited.Category.CategoryId);


            var asignedCategory = new Task
            {
                TaskId = taskDateLimited.TaskId,
                Description = taskDateLimited.Description,
                DateCreated = taskDateLimited.DateCreated,
                DateLimited = taskDateLimited.DateLimited,
                IsCompleted = taskDateLimited.IsCompleted,
                Category = currentCategory
            };

            var result = _taskRepository.UpdateTask(asignedCategory);

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
                    Message = "Tarea completada correctamente"
                };
            }
        }
    }
}
