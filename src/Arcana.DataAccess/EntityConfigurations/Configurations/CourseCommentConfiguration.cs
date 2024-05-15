using Microsoft.EntityFrameworkCore;
using Arcana.Domain.Entities.CourseComments;
using Arcana.DataAccess.EntityConfigurations.Commons;

namespace Arcana.DataAccess.EntityConfigurations.Configurations;

public class CourseCommentConfiguration : IEntityConfiguration
{
    public void Configure(ModelBuilder modelBuilder)
    {
        // CourseComment and Student
        modelBuilder.Entity<CourseComment>()
            .HasOne(courseComment => courseComment.Student)
            .WithMany()
            .HasForeignKey(courseComment => courseComment.StudentId)
            .OnDelete(DeleteBehavior.NoAction);

        // CourseComment and Course
        modelBuilder.Entity<CourseComment>()
            .HasOne(courseComment => courseComment.Course)
            .WithMany(course => course.Comments)
            .HasForeignKey(courseComment => courseComment.CourseId)
            .OnDelete(DeleteBehavior.Restrict);
    }

    public void SeedData(ModelBuilder modelBuilder)
    {
        // CoursesComment
        modelBuilder.Entity<CourseComment>().HasData(
            new CourseComment() { Id = 1, Content = "Course Comment", StudentId = 1, CourseId = 1, CreatedAt = DateTime.UtcNow });
    }
}