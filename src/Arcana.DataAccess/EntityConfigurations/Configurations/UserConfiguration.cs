using Arcana.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Arcana.DataAccess.EntityConfigurations.Commons;

namespace Arcana.DataAccess.EntityConfigurations.Configurations;

public class UserConfiguration : IEntityConfiguration
{
    public void Configure(ModelBuilder modelBuilder)
    {
        // User and Role
        modelBuilder.Entity<User>()
            .HasOne(user => user.Role)
            .WithMany()
            .HasForeignKey(user => user.RoleId)
            .OnDelete(DeleteBehavior.Restrict);
    }

    public void SeedData(ModelBuilder modelBuilder)
    {
        // User
        modelBuilder.Entity<User>().HasData(
            new User()
            {
                Id = 1,
                FirstName = "FirstName1",
                LastName = "LastName1",
                Email = "Email1@gmail.com",
                Password = BCrypt.Net.BCrypt.HashPassword("Password1", BCrypt.Net.BCrypt.GenerateSalt(12)),
                Phone = "+998991111111",
                DateOfBirth = new DateTime(2001, 1, 1),
                RoleId = 1,
                CreatedAt = DateTime.UtcNow
            },
            new User()
            {
                Id = 2,
                FirstName = "FirstName2",
                LastName = "LastName2",
                Email = "Email2@gmail.com",
                Password = BCrypt.Net.BCrypt.HashPassword("Password2", BCrypt.Net.BCrypt.GenerateSalt(12)),
                Phone = "+998992222222",
                DateOfBirth = new DateTime(2002, 2, 2),
                RoleId = 2,
                CreatedAt = DateTime.UtcNow
            },
            new User()
            {
                Id = 3,
                FirstName = "FirstName3",
                LastName = "LastName3",
                Email = "Email3@gmail.com",
                Password = BCrypt.Net.BCrypt.HashPassword("Password3", BCrypt.Net.BCrypt.GenerateSalt(12)),
                Phone = "+998993333333",
                DateOfBirth = new DateTime(2003, 3, 3),
                RoleId = 3,
                CreatedAt = DateTime.UtcNow
            });
    }
}