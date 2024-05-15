using Microsoft.EntityFrameworkCore;
using Arcana.Domain.Entities.QuizQuestions;
using Arcana.DataAccess.EntityConfigurations.Commons;

namespace Arcana.DataAccess.EntityConfigurations.Configurations;

public class QuizQuestionConfiguration : IEntityConfiguration
{
    public void Configure(ModelBuilder modelBuilder)
    {
        // QuizQuestion and Quiz
        modelBuilder.Entity<QuizQuestion>()
            .HasOne(quizQuestion => quizQuestion.Quiz)
            .WithMany()
            .HasForeignKey(quizQuestion => quizQuestion.QuizId)
            .OnDelete(DeleteBehavior.NoAction);

        // QuizQuestion and Question
        modelBuilder.Entity<QuizQuestion>()
            .HasOne(quizQuestion => quizQuestion.Question)
            .WithMany()
            .HasForeignKey(quizQuestion => quizQuestion.QuestionId)
            .OnDelete(DeleteBehavior.Restrict);
    }

    public void SeedData(ModelBuilder modelBuilder)
    {
        // QuizQuestion
        modelBuilder.Entity<QuizQuestion>().HasData(new QuizQuestion() { Id = 1, QuestionId = 1, QuizId = 1, CreatedAt = DateTime.UtcNow });
    }
}