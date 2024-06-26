﻿using Microsoft.EntityFrameworkCore;
using Arcana.Domain.Entities.Courses;
using Arcana.DataAccess.EntityConfigurations.Commons;

namespace Arcana.DataAccess.EntityConfigurations.Configurations;

public class CourseStarConfiguration : IEntityConfiguration
{
    public void Configure(ModelBuilder modelBuilder)
    {
        // CourseStar and Student
        modelBuilder.Entity<CourseStar>()
            .HasOne(courseStar => courseStar.Student)
            .WithMany()
            .HasForeignKey(courseStar => courseStar.StudentId)
            .OnDelete(DeleteBehavior.NoAction);

        // CourseStar and Course
        modelBuilder.Entity<CourseStar>()
            .HasOne(courseStar => courseStar.Course)
            .WithMany(course => course.Stars)
            .HasForeignKey(courseStar => courseStar.CourseId)
            .OnDelete(DeleteBehavior.Restrict);
    }

    public void SeedData(ModelBuilder modelBuilder)
    {
        // CourseStar
        modelBuilder.Entity<CourseStar>().HasData(
            new CourseStar() { Id = 1, StudentId = 1, CourseId = 1, Stars = 5, CreatedAt = DateTime.UtcNow });
    }
}