using System;
using Microsoft.EntityFrameworkCore;
using TodoListMvc.Contexts;
using TodoListMvc.Models;

namespace TodoListMvc.Repository;

public class TaskRepository : ITaskRepository
{
    private readonly AppDbContext _context;

    public TaskRepository(AppDbContext context)
    {
        _context = context;
    }

    private async Task Save()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<TaskItem>> GetAll()
    {
        return await _context.TaskItems.ToListAsync();
    }
    public async Task<bool> IsTitleExists(string title)
    {
        return await _context.TaskItems.AnyAsync(item => item.Title == title);
    }
}
