using Microsoft.EntityFrameworkCore;
using Arcana.Domain.Entities.Lessons;
using Arcana.DataAccess.EntityConfigurations.Commons;

namespace Arcana.DataAccess.EntityConfigurations.Configurations;

public class LessonCommentConfiguration : IEntityConfiguration
{
    public void Configure(ModelBuilder modelBuilder)
    {
        // LessonComment and User
        modelBuilder.Entity<LessonComment>()
            .HasOne(lessonComment => lessonComment.User)
            .WithMany()
            .HasForeignKey(lessonComment => lessonComment.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        // LessonComment and Lesson
        modelBuilder.Entity<LessonComment>()
            .HasOne(lessonComment => lessonComment.Lesson)
            .WithMany(lesson => lesson.Comments)
            .HasForeignKey(lessonComment => lessonComment.LessonId)
            .OnDelete(DeleteBehavior.Restrict);

        // LessonComment and Parent
        modelBuilder.Entity<LessonComment>()
            .HasOne(lessonComment => lessonComment.Parent)
            .WithMany()
            .HasForeignKey(lessonComment => lessonComment.ParentId);
    }

    public void SeedData(ModelBuilder modelBuilder)
    {
        // LessonComment
        modelBuilder.Entity<LessonComment>().HasData(
            new LessonComment() { Id = 1, LessonId = 1, Content = "Lesson Comment", UserId = 2, CreatedAt = DateTime.UtcNow });
    }
}