using System;
using Microsoft.EntityFrameworkCore;
using TodoListMvc.Models;

namespace TodoListMvc.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<TaskItem> TaskItems { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<TaskItem>()
                .HasIndex(item => item.Title)
                .IsUnique();
    }
}
