using System;
using TodoListMvc.Models;

namespace TodoListMvc.Repository;

public interface ITaskRepository
{
    Task<IEnumerable<TaskItem>> GetAll();
    Task<TaskItem?> GetById(int? id);
    Task Add(TaskItem task);
    Task<bool> IsTitleExists(string title);
    Task DeleteAsync(TaskItem taskItem);
}
