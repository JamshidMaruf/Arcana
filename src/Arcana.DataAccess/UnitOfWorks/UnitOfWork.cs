using Arcana.DataAccess.Contexts;
using Arcana.DataAccess.Repositories;
using Arcana.Domain.Entities.Commons;
using Arcana.Domain.Entities.Instructors;
using Arcana.Domain.Entities.Students;
using Arcana.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Arcana.DataAccess.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext context;
    public IRepository<User> Users { get; }
    public IRepository<Asset> Assets { get; }
    public IRepository<Student> Students { get; }
    public IRepository<UserRole> UserRoles { get; }
    public IRepository<Instructor> Instructors { get; }
    public IRepository<Permission> Permissions { get; }
    public IRepository<RolePermission> RolePermissions { get; }
    private IDbContextTransaction transaction;
    public UnitOfWork(AppDbContext context)
    {
        this.context = context;
        Users = new Repository<User>(this.context);
        Assets = new Repository<Asset>(this.context);
        Students = new Repository<Student>(this.context);
        UserRoles = new Repository<UserRole>(this.context);
        Instructors = new Repository<Instructor>(this.context);
        Permissions = new Repository<Permission>(this.context);
        RolePermissions = new Repository<RolePermission>(this.context);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public async ValueTask<bool> SaveAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }

    public async ValueTask BeginTransactionAsync()
    {
        transaction = await this.context.Database.BeginTransactionAsync();
    }

    public async ValueTask CommitTransactionAsync()
    {
        await transaction.CommitAsync();
    }
}
