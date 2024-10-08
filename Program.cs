using Microsoft.EntityFrameworkCore;
using TodoListMvc.Contexts;
using TodoListMvc.Repository;
using TodoListMvc.Seeds;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ITaskRepository, TaskRepository>();

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
                                    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    TaskItemSeed.Initialize(services);
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
