using System;
using TodoListMvc.Models;

namespace TodoListMvc.Repository;

public interface ITaskRepository
{
    Task<IEnumerable<TaskItem>> GetAll();
    Task<bool> IsTitleExists(string title);
}
