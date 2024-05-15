using Microsoft.EntityFrameworkCore;
using Arcana.Domain.Entities.Courses;
using Arcana.DataAccess.EntityConfigurations.Commons;

namespace Arcana.DataAccess.EntityConfigurations.Configurations;

public class CourseModuleConfiguration : IEntityConfiguration
{
    public void Configure(ModelBuilder modelBuilder)
    {
        // CourseModule and Course
        modelBuilder.Entity<CourseModule>()
            .HasOne(courseModule => courseModule.Course)
            .WithMany(course => course.Modules)
            .HasForeignKey(course => course.CourseId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    public void SeedData(ModelBuilder modelBuilder)
    {
        // CourseModule
        modelBuilder.Entity<CourseModule>().HasData(
            new CourseModule() { Id = 1, Name = "Module1", CourseId = 1, CreatedAt = DateTime.UtcNow });
    }
}