using System.ComponentModel.DataAnnotations;
namespace TodoListMvc.Models.ViewModels;

public class EditTaskItemVM
{
    [Required]
    [MaxLength(50, ErrorMessage = "Title can not have more than 50 characters")]
    [MinLength(3, ErrorMessage = "Title need to have at least 3 characters")]
    public string Title { get; set; } = null!;

    [Required]
    [MaxLength(100, ErrorMessage = "Description can not have more than 100 characters")]
    [MinLength(3, ErrorMessage = "Description need to have at least 3 characters")]
    public string Description { get; set; } = null!;

    public bool IsComplete { get; set; }
}
