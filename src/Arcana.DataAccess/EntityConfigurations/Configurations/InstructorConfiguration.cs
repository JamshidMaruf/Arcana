using Microsoft.EntityFrameworkCore;
using Arcana.Domain.Entities.Instructors;
using Arcana.DataAccess.EntityConfigurations.Commons;

namespace Arcana.DataAccess.EntityConfigurations.Configurations;

public class InstructorConfiguration : IEntityConfiguration
{
    public void Configure(ModelBuilder modelBuilder)
    {
        // Instructor and User
        modelBuilder.Entity<Instructor>()
            .HasOne(instructor => instructor.Detail)
            .WithMany()
            .HasForeignKey(instructor => instructor.DetailId);

        // Instructor and Asset
        modelBuilder.Entity<Instructor>()
            .HasOne(instructor => instructor.Picture)
            .WithMany()
            .HasForeignKey(instructor => instructor.PictureId);
    }

    public void SeedData(ModelBuilder modelBuilder)
    {
        // Instructor
        modelBuilder.Entity<Instructor>().HasData(
            new Instructor() { Id = 1, Profession = "Software Developer", About = "Description", DetailId = 3, PictureId = 2, CreatedAt = DateTime.UtcNow });
    }
}