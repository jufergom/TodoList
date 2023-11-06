using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoList.Core;

namespace TodoList.Infrastructure;

public class TodoTaskConfiguration : IEntityTypeConfiguration<TodoTask>
{
    public void Configure(EntityTypeBuilder<TodoTask> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Description).IsRequired();
        builder.Property(t => t.Completed).IsRequired();

        builder.HasOne(t => t.User)
            .WithMany(u => u.TodoTasks)
            .HasForeignKey(t => t.UserId);
    }
}
