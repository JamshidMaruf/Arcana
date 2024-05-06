using Arcana.DataAccess.Repositories;
using Arcana.Domain.Entities.Commons;
using Arcana.Domain.Entities.Instructors;
using Arcana.Domain.Entities.Lessons;
using Arcana.Domain.Entities.Students;
using Arcana.Domain.Entities.Users;
using System.Reflection;

namespace Arcana.DataAccess.UnitOfWorks;

public interface IUnitOfWork : IDisposable
{
    IRepository<User> Users { get; }
    IRepository<Asset> Assets { get; }
    IRepository<Student> Students { get; }
    IRepository<UserRole> UserRoles { get; }
    IRepository<Instructor> Instructors { get; }
    IRepository<Permission> Permissions { get; }
    IRepository<RolePermission> RolePermissions { get; }
    ValueTask<bool> SaveAsync();
    ValueTask BeginTransactionAsync();
    ValueTask CommitTransactionAsync();
}