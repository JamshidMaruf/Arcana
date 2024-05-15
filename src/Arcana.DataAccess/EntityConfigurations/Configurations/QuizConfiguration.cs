using Microsoft.EntityFrameworkCore;
using Arcana.Domain.Entities.Quizzes;
using Arcana.DataAccess.EntityConfigurations.Commons;

namespace Arcana.DataAccess.EntityConfigurations.Configurations;

public class QuizConfiguration : IEntityConfiguration
{
    public void Configure(ModelBuilder modelBuilder)
    {
        // Quiz and CourseModule
        modelBuilder.Entity<Quiz>()
            .HasOne(quiz => quiz.Module)
            .WithMany()
            .HasForeignKey(quiz => quiz.ModuleId);
    }

    public void SeedData(ModelBuilder modelBuilder)
    {
        // Quiz
        modelBuilder.Entity<Quiz>().HasData(new Quiz() { Id = 1, Name = "Quiz1", QuestionCount = 5, ModuleId = 1, CreatedAt = DateTime.UtcNow });
    }
}