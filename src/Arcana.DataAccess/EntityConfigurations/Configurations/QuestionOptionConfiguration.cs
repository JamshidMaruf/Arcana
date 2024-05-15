using Microsoft.EntityFrameworkCore;
using Arcana.Domain.Entities.QuestionOptions;
using Arcana.DataAccess.EntityConfigurations.Commons;

namespace Arcana.DataAccess.EntityConfigurations.Configurations;

public class QuestionOptionConfiguration : IEntityConfiguration
{
    public void Configure(ModelBuilder modelBuilder)
    {
        // QuestionOption and Question
        modelBuilder.Entity<QuestionOption>()
            .HasOne(questionOption => questionOption.Question)
            .WithMany(question => question.Options)
            .HasForeignKey(questionAnswer => questionAnswer.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    public void SeedData(ModelBuilder modelBuilder)
    {
        // QuestionOption
        modelBuilder.Entity<QuestionOption>().HasData(
            new QuestionOption() { Id = 1, Content = "asd", QuestionId = 1, IsCorrect = true, CreatedAt = DateTime.UtcNow },
            new QuestionOption() { Id = 2, Content = "dsd", QuestionId = 1, IsCorrect = false, CreatedAt = DateTime.UtcNow },
            new QuestionOption() { Id = 3, Content = "bdb", QuestionId = 1, IsCorrect = false, CreatedAt = DateTime.UtcNow },
            new QuestionOption() { Id = 4, Content = "waw", QuestionId = 1, IsCorrect = false, CreatedAt = DateTime.UtcNow });
    }
}