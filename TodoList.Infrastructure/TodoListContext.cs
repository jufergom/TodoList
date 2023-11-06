using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TodoList.Core;

namespace TodoList.Infrastructure;

public class TodoListContext : DbContext
{
    public TodoListContext(DbContextOptions<TodoListContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        //seeding
        modelBuilder.Entity<Role>().HasData(
            new Role { Id = 1, RoleName = "Admin" },
            new Role { Id = 2, RoleName = "User" }
        );

        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Username = "admin", Password = "1234", RoleId = 1 },
            new User { Id = 2, Username = "jufergom", Password = "juferpassword", RoleId = 2 }
        );

        modelBuilder.Entity<TodoTask>().HasData(
            new TodoTask { Id = 1, Description = "Hacer tarea 1", Completed = false, UserId = 1 },
            new TodoTask { Id = 2, Description = "Hacer tarea 2", Completed = true, UserId = 1 },
            new TodoTask { Id = 3, Description = "Hacer tarea 3", Completed = false, UserId = 2 }
        );
    }

    public DbSet<User> Users { get; set; }
    public DbSet<TodoTask> TodoTasks { get; set; }
}
