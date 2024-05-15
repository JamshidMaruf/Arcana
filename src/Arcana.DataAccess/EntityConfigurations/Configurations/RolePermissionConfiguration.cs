using Arcana.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Arcana.DataAccess.EntityConfigurations.Commons;

namespace Arcana.DataAccess.EntityConfigurations.Configurations;

public class RolePermissionConfiguration : IEntityConfiguration
{
    public void Configure(ModelBuilder modelBuilder)
    {
        // RolePermission and Role
        modelBuilder.Entity<RolePermission>()
            .HasOne(rolePermission => rolePermission.Role)
            .WithMany()
            .HasForeignKey(rolePermission => rolePermission.RoleId)
            .OnDelete(DeleteBehavior.Cascade);

        // RolePermission and Permission
        modelBuilder.Entity<RolePermission>()
            .HasOne(rolePermission => rolePermission.Permission)
            .WithMany()
            .HasForeignKey(rolePermission => rolePermission.PermissionId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    public void SeedData(ModelBuilder modelBuilder)
    {
        // RolePermission
        modelBuilder.Entity<RolePermission>().HasData(
            new RolePermission() { Id = 1, RoleId = 1, PermissionId = 1, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 2, RoleId = 1, PermissionId = 2, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 3, RoleId = 1, PermissionId = 3, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 4, RoleId = 1, PermissionId = 4, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 5, RoleId = 1, PermissionId = 5, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 6, RoleId = 1, PermissionId = 6, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 7, RoleId = 1, PermissionId = 7, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 8, RoleId = 1, PermissionId = 8, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 9, RoleId = 1, PermissionId = 9, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 10, RoleId = 1, PermissionId = 10, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 11, RoleId = 1, PermissionId = 11, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 12, RoleId = 1, PermissionId = 12, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 13, RoleId = 1, PermissionId = 13, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 14, RoleId = 1, PermissionId = 14, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 15, RoleId = 1, PermissionId = 15, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 16, RoleId = 1, PermissionId = 16, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 17, RoleId = 1, PermissionId = 17, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 18, RoleId = 1, PermissionId = 18, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 19, RoleId = 1, PermissionId = 19, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 20, RoleId = 1, PermissionId = 20, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 21, RoleId = 1, PermissionId = 21, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 22, RoleId = 1, PermissionId = 22, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 23, RoleId = 1, PermissionId = 23, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 24, RoleId = 1, PermissionId = 24, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 25, RoleId = 1, PermissionId = 25, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 26, RoleId = 1, PermissionId = 26, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 27, RoleId = 1, PermissionId = 27, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 28, RoleId = 1, PermissionId = 28, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 29, RoleId = 1, PermissionId = 29, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 30, RoleId = 1, PermissionId = 30, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 31, RoleId = 1, PermissionId = 31, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 32, RoleId = 1, PermissionId = 32, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 33, RoleId = 1, PermissionId = 33, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 34, RoleId = 1, PermissionId = 34, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 35, RoleId = 1, PermissionId = 35, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 36, RoleId = 1, PermissionId = 36, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 37, RoleId = 1, PermissionId = 37, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 38, RoleId = 1, PermissionId = 38, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 39, RoleId = 1, PermissionId = 39, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 40, RoleId = 1, PermissionId = 40, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 41, RoleId = 1, PermissionId = 41, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 42, RoleId = 1, PermissionId = 42, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 43, RoleId = 1, PermissionId = 43, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 44, RoleId = 1, PermissionId = 44, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 45, RoleId = 1, PermissionId = 45, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 46, RoleId = 1, PermissionId = 46, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 47, RoleId = 1, PermissionId = 47, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 48, RoleId = 1, PermissionId = 48, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 49, RoleId = 1, PermissionId = 49, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 50, RoleId = 1, PermissionId = 50, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 51, RoleId = 1, PermissionId = 51, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 52, RoleId = 1, PermissionId = 52, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 53, RoleId = 1, PermissionId = 53, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 54, RoleId = 1, PermissionId = 54, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 55, RoleId = 1, PermissionId = 55, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 56, RoleId = 1, PermissionId = 56, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 57, RoleId = 1, PermissionId = 57, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 58, RoleId = 1, PermissionId = 58, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 59, RoleId = 1, PermissionId = 59, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 60, RoleId = 1, PermissionId = 60, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 61, RoleId = 1, PermissionId = 61, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 62, RoleId = 1, PermissionId = 62, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 63, RoleId = 1, PermissionId = 63, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 64, RoleId = 1, PermissionId = 64, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 65, RoleId = 1, PermissionId = 65, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 66, RoleId = 1, PermissionId = 66, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 67, RoleId = 1, PermissionId = 67, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 68, RoleId = 1, PermissionId = 68, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 69, RoleId = 1, PermissionId = 69, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 70, RoleId = 1, PermissionId = 70, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 71, RoleId = 1, PermissionId = 71, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 72, RoleId = 1, PermissionId = 72, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 73, RoleId = 1, PermissionId = 73, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 74, RoleId = 1, PermissionId = 74, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 75, RoleId = 1, PermissionId = 75, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 76, RoleId = 1, PermissionId = 76, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 77, RoleId = 1, PermissionId = 77, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 78, RoleId = 1, PermissionId = 78, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 79, RoleId = 1, PermissionId = 79, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 80, RoleId = 1, PermissionId = 80, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 81, RoleId = 1, PermissionId = 81, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 82, RoleId = 1, PermissionId = 82, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 83, RoleId = 1, PermissionId = 83, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 84, RoleId = 1, PermissionId = 84, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 86, RoleId = 1, PermissionId = 86, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 87, RoleId = 1, PermissionId = 87, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 88, RoleId = 1, PermissionId = 88, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 89, RoleId = 1, PermissionId = 89, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 90, RoleId = 1, PermissionId = 90, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 91, RoleId = 1, PermissionId = 91, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 92, RoleId = 1, PermissionId = 92, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 93, RoleId = 1, PermissionId = 93, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 94, RoleId = 1, PermissionId = 94, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 95, RoleId = 1, PermissionId = 95, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 96, RoleId = 1, PermissionId = 96, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 97, RoleId = 1, PermissionId = 97, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 98, RoleId = 1, PermissionId = 98, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 99, RoleId = 1, PermissionId = 99, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 100, RoleId = 1, PermissionId = 100, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 101, RoleId = 1, PermissionId = 101, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 102, RoleId = 1, PermissionId = 102, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 103, RoleId = 1, PermissionId = 103, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 104, RoleId = 1, PermissionId = 104, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 105, RoleId = 1, PermissionId = 105, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 106, RoleId = 1, PermissionId = 106, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 107, RoleId = 1, PermissionId = 107, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 108, RoleId = 1, PermissionId = 108, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 109, RoleId = 1, PermissionId = 109, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 110, RoleId = 1, PermissionId = 110, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 111, RoleId = 1, PermissionId = 111, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 112, RoleId = 1, PermissionId = 112, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 113, RoleId = 1, PermissionId = 113, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 114, RoleId = 1, PermissionId = 114, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 115, RoleId = 1, PermissionId = 115, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 116, RoleId = 1, PermissionId = 116, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 117, RoleId = 1, PermissionId = 117, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 118, RoleId = 1, PermissionId = 118, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 119, RoleId = 1, PermissionId = 119, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 120, RoleId = 1, PermissionId = 120, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 121, RoleId = 1, PermissionId = 121, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 122, RoleId = 1, PermissionId = 122, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 123, RoleId = 1, PermissionId = 123, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 124, RoleId = 1, PermissionId = 124, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 125, RoleId = 1, PermissionId = 125, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 126, RoleId = 1, PermissionId = 126, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 127, RoleId = 1, PermissionId = 127, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 128, RoleId = 1, PermissionId = 128, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 129, RoleId = 1, PermissionId = 129, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 130, RoleId = 1, PermissionId = 130, CreatedAt = DateTime.UtcNow }
            );
    }
}
