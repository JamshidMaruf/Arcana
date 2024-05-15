using Microsoft.EntityFrameworkCore;
using Arcana.Domain.Entities.Instructors;
using Arcana.DataAccess.EntityConfigurations.Commons;

namespace Arcana.DataAccess.EntityConfigurations.Configurations;

public class InstructorCommentConfiguration : IEntityConfiguration
{
    public void Configure(ModelBuilder modelBuilder)
    {
        // InstructorComment and Student
        modelBuilder.Entity<InstructorComment>()
            .HasOne(instructorComment => instructorComment.Student)
            .WithMany()
            .HasForeignKey(instructorComment => instructorComment.StudentId)
            .OnDelete(DeleteBehavior.NoAction);

        // InstructorComment and Instructor
        modelBuilder.Entity<InstructorComment>()
            .HasOne(instructorComment => instructorComment.Instructor)
            .WithMany(instructor => instructor.Comments)
            .HasForeignKey(instructorComment => instructorComment.InstructorId)
            .OnDelete(DeleteBehavior.Restrict);
    }

    public void SeedData(ModelBuilder modelBuilder)
    {
        // InstructorComment
        modelBuilder.Entity<InstructorComment>().HasData(
            new InstructorComment() { Id = 1, StudentId = 1, InstructorId = 1, CreatedAt = DateTime.UtcNow });
    }
}