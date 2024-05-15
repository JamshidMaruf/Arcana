using Microsoft.EntityFrameworkCore;
using Arcana.Domain.Entities.Students;
using Arcana.DataAccess.EntityConfigurations.Commons;

namespace Arcana.DataAccess.EntityConfigurations.Configurations;

public class StudentConfiguration : IEntityConfiguration
{
    public void Configure(ModelBuilder modelBuilder)
    {
        // Student and User 
        modelBuilder.Entity<Student>()
            .HasOne(student => student.Detail)
            .WithMany()
            .HasForeignKey(student => student.DetailId);

        // Student and Asset
        modelBuilder.Entity<Student>()
            .HasOne(student => student.Picture)
            .WithMany()
            .HasForeignKey(student => student.PictureId);
    }

    public void SeedData(ModelBuilder modelBuilder)
    {
        // Student
        modelBuilder.Entity<Student>().HasData(
            new Student() { Id = 1, DetailId = 2, PictureId = 1, CreatedAt = DateTime.UtcNow });
    }
}