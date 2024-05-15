using Microsoft.EntityFrameworkCore;
using Arcana.Domain.Entities.QuestionAnswers;
using Arcana.DataAccess.EntityConfigurations.Commons;

namespace Arcana.DataAccess.EntityConfigurations.Configurations;

public class QuestionAnswerConfiguration : IEntityConfiguration
{
    public void Configure(ModelBuilder modelBuilder)
    {
        // QuestionAnswer and Question
        modelBuilder.Entity<QuestionAnswer>()
             .HasOne(quizApplication => quizApplication.Question)
             .WithMany()
             .HasForeignKey(quizApplication => quizApplication.QuestionId)
             .OnDelete(DeleteBehavior.NoAction);

        // QuestionAnswer and Student
        modelBuilder.Entity<QuestionAnswer>()
            .HasOne(quizApplication => quizApplication.Student)
            .WithMany()
            .HasForeignKey(quizApplication => quizApplication.StudentId)
            .OnDelete(DeleteBehavior.Restrict);
    }

    public void SeedData(ModelBuilder modelBuilder)
    {
        // QuizAnswer
        modelBuilder.Entity<QuestionAnswer>().HasData(
            new QuestionAnswer() { Id = 1, QuizId = 1, StudentId = 1, QuestionId = 1, OptionId = 1, CreatedAt = DateTime.UtcNow });
    }
}