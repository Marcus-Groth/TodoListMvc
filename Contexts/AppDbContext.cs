using System;
using Microsoft.EntityFrameworkCore;
using TodoListMvc.Models;

namespace TodoListMvc.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<TaskItem> TaskItems { get; set; }
}
