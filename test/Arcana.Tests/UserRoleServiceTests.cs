using Arcana.DataAccess.UnitOfWorks;
using Arcana.Domain.Entities.Users;
using Arcana.Service.Configurations;
using Arcana.Service.Services.UserRoles;
using Bogus;
using FluentAssertions;
using NSubstitute;
using System.Linq.Expressions;

namespace Arcana.Tests;

public class UserRoleServiceTests
{
    private readonly IUnitOfWork unitOfWorkMock;
    private readonly IUserRoleService userRoleService;

    public UserRoleServiceTests()
    {
        unitOfWorkMock = Substitute.For<IUnitOfWork>();
        userRoleService = new UserRoleService(unitOfWorkMock);  
    }

    [Fact]
    public async Task CreateAsyn_Should_Create_New_Role()
    {
        // Arrange
        var userRole = new Faker<UserRole>()
            .RuleFor(role => role.Name, fake => fake.Name.FirstName())
            .Generate();

        unitOfWorkMock.UserRoles
            .InsertAsync(Arg.Any<UserRole>())
            .Returns(await Task.FromResult(userRole));

        var createdUserRole = await userRoleService.CreateAsync(userRole);

        // Assert
        createdUserRole.Should().NotBeNull();
        createdUserRole.Name.Should().BeSameAs(userRole.Name);
    }

    [Fact]
    public async Task DeleteAsync_Should_Remove_Exist_Role()
    {
        // Arrange
        var roleId = 1;
        var existingRole = new UserRole { Id = roleId };

        unitOfWorkMock.UserRoles
            .SelectAsync(Arg.Any<Expression<Func<UserRole, bool>>>())
            .Returns(await Task.FromResult(existingRole));

        // Act
        var result = await userRoleService.DeleteAsync(roleId);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public async Task GetByIdAsync_Should_Return_Exist_Role()
    {
        // Arrange
        var roleId = 2;
        var existingRole = new UserRole { Id = roleId };

        unitOfWorkMock.UserRoles
            .SelectAsync(Arg.Any<Expression<Func<UserRole, bool>>>())
            .Returns(await Task.FromResult(existingRole));

        // Act
        var result = await userRoleService.GetByIdAsync(roleId);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(roleId);
    }

    [Fact]
    public async Task GetAllAsync_Should_Return_RoleList()
    {
        // Arrange
        var existingRoles = Enumerable.Empty<UserRole>().AsQueryable();

        unitOfWorkMock.UserRoles
            .SelectAsQueryable()
            .Returns(existingRoles);

        var paginationParams = new PaginationParams() { PageIndex = 1, PageSize = 5};
        var filter = new Filter();

        // Act
        var result = await userRoleService.GetAllAsync(paginationParams, filter);

        // Assert
        result.Should().NotBeNull();
    }
}
