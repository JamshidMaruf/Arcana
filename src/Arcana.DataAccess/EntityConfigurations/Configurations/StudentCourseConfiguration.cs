using Microsoft.EntityFrameworkCore;
using Arcana.Domain.Entities.StudentCourses;
using Arcana.DataAccess.EntityConfigurations.Commons;

namespace Arcana.DataAccess.EntityConfigurations.Configurations;

public class StudentCourseConfiguration : IEntityConfiguration
{
    public void Configure(ModelBuilder modelBuilder)
    {
        // StudentCourse and Student
        modelBuilder.Entity<StudentCourse>()
            .HasOne(studentCourse => studentCourse.Student)
            .WithMany(student => student.Courses)
            .HasForeignKey(studentCourse => studentCourse.StudentId)
            .OnDelete(DeleteBehavior.NoAction);

        // StudentCourse and Course
        modelBuilder.Entity<StudentCourse>()
            .HasOne(studentCourse => studentCourse.Course)
            .WithMany()
            .HasForeignKey(studentCourse => studentCourse.CourseId)
            .OnDelete(DeleteBehavior.Restrict);
    }

    public void SeedData(ModelBuilder modelBuilder)
    {
        // StudentCourse
        modelBuilder.Entity<StudentCourse>().HasData(
            new StudentCourse() { Id = 1, CourseId = 1, StudentId = 1, CreatedAt = DateTime.UtcNow });
    }
}