using System;
using System.ComponentModel.DataAnnotations;

namespace TodoListMvc.Models;

public class TaskItem
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public string Description { get; set; } = string.Empty;

    [Display(Name = "Completed")]
    public bool IsComplete { get; set; }
}
