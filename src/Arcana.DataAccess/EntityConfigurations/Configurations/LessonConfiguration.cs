using Microsoft.EntityFrameworkCore;
using Arcana.Domain.Entities.Lessons;
using Arcana.DataAccess.EntityConfigurations.Commons;

namespace Arcana.DataAccess.EntityConfigurations.Configurations;

public class LessonConfiguration : IEntityConfiguration
{
    public void Configure(ModelBuilder modelBuilder)
    {
        // Lesson and Asset
        modelBuilder.Entity<Lesson>()
            .HasOne(lesson => lesson.File)
            .WithMany()
            .HasForeignKey(lesson => lesson.FileId);

        // Lesson and CourseModule
        modelBuilder.Entity<Lesson>()
            .HasOne(lesson => lesson.Module)
            .WithMany(module => module.Lessons)
            .HasForeignKey(lesson => lesson.ModuleId)
            .OnDelete(DeleteBehavior.NoAction);
    }

    public void SeedData(ModelBuilder modelBuilder)
    {
        // Lesson
        modelBuilder.Entity<Lesson>().HasData(
            new Lesson() { Id = 1, Title = "Lesson1", Description = "Lesson Description", FileId = 2, ModuleId = 1, CreatedAt = DateTime.UtcNow });
    }
}