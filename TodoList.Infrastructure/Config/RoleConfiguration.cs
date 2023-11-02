using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoList.Core;

namespace TodoList.Infrastructure;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(r => r.RoleId);
        builder.Property(r => r.RoleName).IsRequired();

        builder.HasMany(r => r.Users)
            .WithOne(u => u.Role);
    }
}
