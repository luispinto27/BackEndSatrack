using Microsoft.AspNetCore.Mvc;
using TaskManager.Business.Helpers.DTO;
using TaskManager.Business.Services.Tasks;
using TaskManager.Data.Models;
using Task = TaskManager.Data.Models.Task;

namespace TaskManager.API.Controllers.TaskController
{
    [ApiController]
    [Route("api/task")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskServices _taskServices;

        private TaskController(ITaskServices taskServices)
        {
            _taskServices = taskServices;
        }

        [HttpGet]
        public List<Task> GetAllTask()
        {
            return _taskServices.GetAllTasks();
        }

        [HttpGet("CategoryId")]
        public IActionResult GetTaskById(int taskId)
        {
            var response = _taskServices.GetTaskById(taskId);

            return Ok(response);
        }

        [HttpPost]
        public IActionResult CreateTask(TaskDTO taskCreated)
        {
            var response = _taskServices.CreateTask(taskCreated);

            return Ok(response);
        }

        [HttpPut]
        public IActionResult UpdateTask(TaskDTO taskUpdate)
        {
            var response = _taskServices.UpdateTask(taskUpdate);

            return Ok(response);
        }

        [HttpDelete("TaskId")]
        public IActionResult DeleteTask(int categoryId)
        {
            var response = _taskServices.DeleteTask(categoryId);

            return Ok(response);
        }

    }
}
