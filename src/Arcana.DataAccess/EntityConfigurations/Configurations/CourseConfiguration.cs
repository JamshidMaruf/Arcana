using Arcana.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Arcana.Domain.Entities.Courses;
using Arcana.DataAccess.EntityConfigurations.Commons;

namespace Arcana.DataAccess.EntityConfigurations.Configurations;

public class CourseConfiguration : IEntityConfiguration
{
    public void Configure(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>()
           .Property(c => c.Price)
           .HasColumnType("decimal(18,3)");

        // Course and CourseCategory
        modelBuilder.Entity<Course>()
            .HasOne(course => course.Category)
            .WithMany()
            .HasForeignKey(course => course.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        // Course and Instructor
        modelBuilder.Entity<Course>()
            .HasOne(course => course.Instructor)
            .WithMany(instructor => instructor.Courses)
            .HasForeignKey(course => course.InstructorId);

        // Course and Asset
        modelBuilder.Entity<Course>()
            .HasOne(course => course.File)
            .WithMany()
            .HasForeignKey(course => course.FileId);

        // Course and Language
        modelBuilder.Entity<Course>()
            .HasOne(course => course.Language)
            .WithMany()
            .HasForeignKey(course => course.LanguageId);
    }

    public void SeedData(ModelBuilder modelBuilder)
    {
        // Course
        modelBuilder.Entity<Course>().HasData(
            new Course
            {
                Id = 1,
                Name = ".NET",
                Description = "Course Description",
                Price = 2200000.00m,
                Duration = 7,
                CountOfLessons = 150,
                Level = Level.Advanced,
                CategoryId = 1,
                InstructorId = 1,
                FileId = 1,
                LanguageId = 1,
                CreatedAt = DateTime.UtcNow
            });
    }
}