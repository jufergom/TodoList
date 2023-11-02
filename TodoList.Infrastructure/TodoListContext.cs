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
            new Role { RoleId = 1, RoleName = "Admin" },
            new Role { RoleId = 2, RoleName = "User" }
        );

        modelBuilder.Entity<User>().HasData(
            new User { UserId = 1, Username = "admin", Password = "1234", RoleId = 1 },
            new User { UserId = 2, Username = "jufergom", Password = "juferpassword", RoleId = 2 }
        );

        modelBuilder.Entity<TodoTask>().HasData(
            new TodoTask { TodoTaskId = 1, Description = "Hacer tarea 1", Completed = false, UserId = 1 },
            new TodoTask { TodoTaskId = 2, Description = "Hacer tarea 2", Completed = true, UserId = 1 },
            new TodoTask { TodoTaskId = 3, Description = "Hacer tarea 3", Completed = false, UserId = 2 }
        );
    }

    public DbSet<User> Users { get; set; }
    public DbSet<TodoTask> TodoTasks { get; set; }
}
