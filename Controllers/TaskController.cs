using Microsoft.AspNetCore.Mvc;
using TodoListMvc.Repository;

namespace TodoListMvc.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskRepository _taskRepository;

        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<ActionResult> Index()
        {
            var taskItems = await _taskRepository.GetAll();
            return View(taskItems);
        }
    }
}
