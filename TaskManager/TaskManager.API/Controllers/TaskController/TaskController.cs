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

        public TaskController(ITaskServices taskServices)
        {
            _taskServices = taskServices;
        }

        [HttpGet("Get/")]
        public List<Task> GetAllTask()
        {
            return _taskServices.GetAllTasks();
        }

        [HttpGet("Get/{TaskId}")]
        public IActionResult GetTaskById(int taskId)
        {
            var response = _taskServices.GetTaskById(taskId);

            return Ok(response);
        }

        [HttpPost("Create/")]
        public IActionResult CreateTask(TaskDTO taskCreated)
        {
            var response = _taskServices.CreateTask(taskCreated);

            return Ok(response);
        }

        [HttpPut("Update/")]
        public IActionResult UpdateTask(TaskDTO taskUpdate)
        {
            var response = _taskServices.UpdateTask(taskUpdate);

            return Ok(response);
        }

        [HttpDelete("Delete/{TaskId}")]
        public IActionResult DeleteTask(int taskId)
        {
            var response = _taskServices.DeleteTask(taskId);

            return Ok(response);
        }

        [HttpGet("Completed/{TaskId}")]
        public IActionResult CompletedTask(int taskId)
        {
            var response = _taskServices.CompletedTask(taskId);

            return Ok(response);
        }

        [HttpGet("Asigned/{TaskId}/{CategoryId}")]
        public IActionResult AsignedCategory(int taskId, int categoryId)
        {
            var response = _taskServices.AsignedCategory(taskId, categoryId);

            return Ok(response);
        }

        [HttpPost("AsignedDateLimited/")]
        public IActionResult AsignedDateLimited(Task taskDateLimited)
        {
            var response = _taskServices.AsignedDateLimited(taskDateLimited);

            return Ok(response);


        }
    }
}
