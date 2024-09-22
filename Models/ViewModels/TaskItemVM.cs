using System.ComponentModel.DataAnnotations;
namespace TodoListMvc.Models.ViewModels;

public class TaskItemVM
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }

    [Display(Name = "Completed")]
    public bool IsComplete { get; set; }
}