using Microsoft.AspNetCore.Mvc;
using TodoListMvc.Models;
using TodoListMvc.Repository;

namespace TodoListMvc.Controllers;

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

    [HttpPost]
    public async Task<IActionResult> Create([Bind("Title,Description,IsComplete")] TaskItem taskItem)
    {
        ValidateTaskItem(taskItem);

        if (ModelState.IsValid)
        {
            await _taskRepository.Add(taskItem);
            return RedirectToAction(nameof(Index));
        }

        return View(taskItem);
    }

    private async void ValidateTaskItem(TaskItem taskItem)
    {
        if (taskItem.Title == taskItem.Description)
        {
            ModelState.AddModelError("Title",
                                     "Title name can not be the same as Decription.");
        }


        if (await _taskRepository.IsTitleExists(taskItem.Title))
        {
            ModelState.AddModelError("Title",
                                     "Title already exists");
        }
    }
}