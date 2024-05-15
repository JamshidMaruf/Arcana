using Arcana.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Arcana.DataAccess.EntityConfigurations.Commons;

namespace Arcana.DataAccess.EntityConfigurations.Configurations;

public class UserRoleConfiguration : IEntityConfiguration
{
    public void Configure(ModelBuilder modelBuilder)
    { }

    public void SeedData(ModelBuilder modelBuilder)
    {
        // UserRole
        modelBuilder.Entity<UserRole>().HasData(
            new UserRole { Id = 1, Name = "Admin", CreatedAt = DateTime.UtcNow },
            new UserRole { Id = 2, Name = "Student", CreatedAt = DateTime.UtcNow },
            new UserRole { Id = 3, Name = "Instructor", CreatedAt = DateTime.UtcNow });
    }
}