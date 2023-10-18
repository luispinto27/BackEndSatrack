using Microsoft.AspNetCore.Mvc;
using TaskManager.Business.Services.Tasks;
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
        
    }
}
