using Microsoft.EntityFrameworkCore;
using Arcana.Domain.Entities.Instructors;
using Arcana.DataAccess.EntityConfigurations.Commons;

namespace Arcana.DataAccess.EntityConfigurations.Configurations;

public class InstructorStarConfiguration : IEntityConfiguration
{
    public void Configure(ModelBuilder modelBuilder)
    {
        // InstructorStar and Student
        modelBuilder.Entity<InstructorStar>()
            .HasOne(instructorStar => instructorStar.Student)
            .WithMany()
            .HasForeignKey(instructorStar => instructorStar.StudentId)
            .OnDelete(DeleteBehavior.NoAction);

        // InstructorStar and Instructor
        modelBuilder.Entity<InstructorStar>()
            .HasOne(instructorStar => instructorStar.Instructor)
            .WithMany(instructor => instructor.Stars)
            .HasForeignKey(instructorStar => instructorStar.InstructorId)
            .OnDelete(DeleteBehavior.Restrict);
    }

    public void SeedData(ModelBuilder modelBuilder)
    {
        // InstructorStars
        modelBuilder.Entity<InstructorStar>().HasData(
            new InstructorStar() { Id = 1, Stars = 5, StudentId = 1, InstructorId = 1, CreatedAt = DateTime.UtcNow });
    }
}