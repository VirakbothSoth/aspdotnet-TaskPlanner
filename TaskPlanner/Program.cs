using Microsoft.EntityFrameworkCore;
using TaskPlanner.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("TaskPlannerDb"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    if (!db.TaskItems.Any())
    {
        var now = DateTime.Now;

        db.TaskItems.AddRange(
            new TaskItem
            {
                Id = 1,
                Title = "Plan Sprint",
                Description = "Define goals and assign tickets for the upcoming sprint.",
                Priority = Priority.High,
                EndDate = now.AddDays(2),
                Hashtag = "#planning",
                Comment = "Check with team lead first.",
                IsCompleted = false
            },
            new TaskItem
            {
                Id = 2,
                Title = "Design Database Schema",
                Description = "Create ERD and finalize table relationships.",
                Priority = Priority.High,
                EndDate = now.AddDays(3),
                Hashtag = "#backend",
                IsCompleted = false
            },
            new TaskItem
            {
                Id = 3,
                Title = "Write Entity Classes",
                Description = "C# model classes based on ERD.",
                Priority = Priority.Medium,
                EndDate = now.AddDays(4),
                Hashtag = "#backend",
                IsCompleted = false,
                ParentTaskId = 2
            },
            new TaskItem
            {
                Id = 4,
                Title = "Configure DbContext",
                Description = "Set up EF Core relationships and InMemory DB.",
                Priority = Priority.Medium,
                EndDate = now.AddDays(4),
                Hashtag = "#backend",
                IsCompleted = true,
                ParentTaskId = 2
            },
            new TaskItem
            {
                Id = 5,
                Title = "Build Task List UI",
                Description = "Design and implement the index page.",
                Priority = Priority.Medium,
                EndDate = now.AddDays(7),
                Hashtag = "#frontend",
                IsCompleted = false
            },
            new TaskItem
            {
                Id = 6,
                Title = "Write Unit Tests",
                Description = "Cover controller actions and service layer.",
                Priority = Priority.Low,
                EndDate = now.AddDays(14),
                Hashtag = "#testing",
                IsCompleted = false
            },
            new TaskItem
            {
                Id = 7,
                Title = "Deploy to Staging",
                Description = "Push to staging and run smoke tests.",
                Priority = Priority.Low,
                EndDate = now.AddDays(21),
                Hashtag = "#devops",
                IsCompleted = false
            }
        );

        db.SaveChanges();
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
