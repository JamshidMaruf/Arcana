using Arcana.Domain.Entities.Instructors;
using Arcana.Domain.Entities.Lessons;
using Arcana.Domain.Entities.Students;
using Arcana.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Arcana.DataAccess.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<UserRole> Roles { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }
}