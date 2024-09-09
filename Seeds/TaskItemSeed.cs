using System;
using Microsoft.EntityFrameworkCore;
using TodoListMvc.Contexts;
using TodoListMvc.Models;

namespace TodoListMvc.Seeds;

public static class TaskItemSeed
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new AppDbContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<AppDbContext>>()))
        {

            if (context.TaskItems.Any())
            {
                return;
            }

            context.TaskItems.AddRange(

                new TaskItem
                {
                    Id = 1,
                    Title = "Complete Project Documentation",
                    Description = "Finish writing the documentation for the project.",
                    IsComplete = false
                },
                new TaskItem
                {
                    Id = 2,
                    Title = "Team Meeting",
                    Description = "Attend the scheduled team meeting on project progress.",
                    IsComplete = true
                },
                new TaskItem
                {
                    Id = 3,
                    Title = "Code Review",
                    Description = "Review code submitted by the development team.",
                    IsComplete = false
                },
                new TaskItem
                {
                    Id = 4,
                    Title = "Fix UI Bugs",
                    Description = "Resolve the reported UI issues on the main dashboard.",
                    IsComplete = true
                },
                new TaskItem
                {
                    Id = 5,
                    Title = "Deploy to Production",
                    Description = "Deploy the latest build to the production environment.",
                    IsComplete = false
                }
            );
            context.SaveChanges();
        }
    }
}
