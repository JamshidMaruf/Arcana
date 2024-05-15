using Microsoft.EntityFrameworkCore;
using Arcana.Domain.Entities.CourseCategories;
using Arcana.DataAccess.EntityConfigurations.Commons;

namespace Arcana.DataAccess.EntityConfigurations.Configurations;

public class CourseCategoryConfiguration : IEntityConfiguration
{
    public void Configure(ModelBuilder modelBuilder)
    { }

    public void SeedData(ModelBuilder modelBuilder)
    {
        // CourseCategory
        modelBuilder.Entity<CourseCategory>().HasData(
            new CourseCategory() { Id = 1, Name = "IT", CreatedAt = DateTime.UtcNow });
    }
}