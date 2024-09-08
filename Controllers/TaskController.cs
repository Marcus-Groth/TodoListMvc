using Microsoft.AspNetCore.Mvc;
using TodoListMvc.Models;

namespace TodoListMvc.Controllers
{
    public class TaskController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<TaskItem> tasks = new List<TaskItem>()
            {
                new TaskItem { Id = 1, Title = "Task 1", Description = "Description 1", IsComplete = false },
                new TaskItem { Id = 2, Title = "Task 2", Description = "Description 2", IsComplete = false },
                new TaskItem { Id = 3, Title = "Task 3", Description = "Description 3", IsComplete = false }
            };

            return View(tasks);
        }
    }
}
