using Microsoft.EntityFrameworkCore;
using Arcana.Domain.Entities.Questions;
using Arcana.DataAccess.EntityConfigurations.Commons;

namespace Arcana.DataAccess.EntityConfigurations.Configurations;

public class QuestionConfiguration : IEntityConfiguration
{
    public void Configure(ModelBuilder modelBuilder)
    {
        // Question and Asset
        modelBuilder.Entity<Question>()
            .HasOne(question => question.File)
            .WithMany()
            .HasForeignKey(question => question.FileId);

        // Question and CourseModule
        modelBuilder.Entity<Question>()
            .HasOne(question => question.Module)
            .WithMany()
            .HasForeignKey(question => question.ModuleId);
    }

    public void SeedData(ModelBuilder modelBuilder)
    {
        // Question
        modelBuilder.Entity<Question>().HasData(new Question() { Id = 1, Content = "Content", FileId = 2, ModuleId = 1, CreatedAt = DateTime.UtcNow });

    }
}