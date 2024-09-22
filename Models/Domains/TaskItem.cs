using System;
using System.ComponentModel.DataAnnotations;

namespace TodoListMvc.Models;

public class TaskItem
{
    [Key]
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool IsComplete { get; set; }
}
