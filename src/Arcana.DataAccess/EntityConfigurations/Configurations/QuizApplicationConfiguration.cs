using Microsoft.EntityFrameworkCore;
using Arcana.Domain.Entities.QuizApplications;
using Arcana.DataAccess.EntityConfigurations.Commons;

namespace Arcana.DataAccess.EntityConfigurations.Configurations;

public class QuizApplicationConfiguration : IEntityConfiguration
{
    public void Configure(ModelBuilder modelBuilder)
    {
        // QuizApplication and Student
        modelBuilder.Entity<QuizApplication>()
             .HasOne(quizApplication => quizApplication.Student)
             .WithMany(student => student.QuizApplications)
             .HasForeignKey(quizApplication => quizApplication.StudentId)
             .OnDelete(DeleteBehavior.NoAction);

        // QuizApplication and Quiz
        modelBuilder.Entity<QuizApplication>()
            .HasOne(quizApplication => quizApplication.Quiz)
            .WithMany()
            .HasForeignKey(quizApplication => quizApplication.QuizId)
            .OnDelete(DeleteBehavior.Restrict);
    }

    public void SeedData(ModelBuilder modelBuilder)
    {
        // QuizApplication
        modelBuilder.Entity<QuizApplication>().HasData(new QuizApplication() { Id = 1, QuizId = 1, StudentId = 1, StartTime = new DateTime(2024, 10, 8, 10, 0, 0), EndTime = new DateTime(2024, 11, 8, 10, 0, 0), CreatedAt = DateTime.UtcNow });
    }
}