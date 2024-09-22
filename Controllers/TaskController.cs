using Microsoft.AspNetCore.Mvc;
using TodoListMvc.Models;
using TodoListMvc.Models.ViewModels;
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

        var taskItemsVM = taskItems.Select(task => new TaskItemVM
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            IsComplete = task.IsComplete
        });

        return View(taskItemsVM);
    }

    public async Task<ActionResult> Details(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var taskItem = await _taskRepository.GetById(id);

        if (taskItem is null)
        {
            return NotFound();
        }

        var taskItemVM = new TaskItemVM
        {
            Id = taskItem.Id,
            Title = taskItem.Title,
            Description = taskItem.Description,
            IsComplete = taskItem.IsComplete
        };

        return View(taskItemVM);
    }

    public IActionResult Create()
    {
        return View();
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var taskItem = await _taskRepository.GetById(id);

        if (taskItem is null)
        {
            return NotFound();
        }

        var editTaskItemVM = new EditTaskItemVM
        {
            Title = taskItem.Title,
            Description = taskItem.Description,
            IsComplete = taskItem.IsComplete
        };

        return View(editTaskItemVM);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var taskItem = await _taskRepository.GetById(id);

        if (taskItem is null)
        {
            return NotFound();
        }

        await _taskRepository.DeleteAsync(taskItem);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Create([Bind("Title,Description,IsComplete")] CreateTaskItemVM createTaskItemVM)
    {
        if (!ModelState.IsValid)
        {
            return View(createTaskItemVM);
        }

        var taskItem = new TaskItem
        {
            Title = createTaskItemVM.Title,
            Description = createTaskItemVM.Description,
            IsComplete = createTaskItemVM.IsComplete
        };

            await _taskRepository.Add(taskItem);
            return RedirectToAction(nameof(Index));
        }

        return View(taskItem);
    }

    [HttpPost]
    public async Task<IActionResult> Edit([Bind("Title,Description,IsComplete")] EditTaskItemVM editTaskItemVM, int? id)
    {
        var taskItem = await _taskRepository.GetById(id);

        if (taskItem is null)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            return View(editTaskItemVM);
        }

        taskItem.Title = editTaskItemVM.Title;
        taskItem.Description = editTaskItemVM.Description;
        taskItem.IsComplete = editTaskItemVM.IsComplete;

            await _taskRepository.UpdateAsync(taskItem);
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