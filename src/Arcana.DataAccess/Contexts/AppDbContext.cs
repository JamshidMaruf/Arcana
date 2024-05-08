using Arcana.Domain.Entities.Commons;
using Arcana.Domain.Entities.CourseCategories;
using Arcana.Domain.Entities.CourseComments;
using Arcana.Domain.Entities.Courses;
using Arcana.Domain.Entities.Instructors;
using Arcana.Domain.Entities.Languages;
using Arcana.Domain.Entities.Lessons;
using Arcana.Domain.Entities.QuestionAnswers;
using Arcana.Domain.Entities.Questions;
using Arcana.Domain.Entities.QuizApplications;
using Arcana.Domain.Entities.QuizQuestions;
using Arcana.Domain.Entities.Quizzes;
using Arcana.Domain.Entities.StudentCourses;
using Arcana.Domain.Entities.Students;
using Arcana.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Arcana.DataAccess.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Asset> Assets { get; set; }
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<CourseStars> CourseStars { get; set; }
    public DbSet<CourseModule> CourseModules { get; set; }
    public DbSet<QuizQuestion> QuizQuestions { get; set; }
    public DbSet<CourseComment> CourseComments { get; set; }
    public DbSet<LessonComment> LessonComments { get; set; }
    public DbSet<StudentCourse> StudentCourses { get; set; }
    public DbSet<QuestionAnswer> QuestionAnswers { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }
    public DbSet<CourseCategory> CourseCategories { get; set; }
    public DbSet<InstructorStar> InstructorStars { get; set; }
    public DbSet<QuizApplication> QuizApplications { get; set; }
    public DbSet<InstructorComment> InstructorComments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>()
            .Property(c => c.Price)
            .HasColumnType("decimal(18,3)");

        modelBuilder.Entity<InstructorComment>()
            .HasOne(i => i.Student)
            .WithMany()
            .HasForeignKey(i => i.StudentId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<InstructorComment>()
            .HasOne(i => i.Instructor)
            .WithMany()
            .HasForeignKey(i => i.InstructorId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<InstructorStar>()
           .HasOne(i => i.Student)
           .WithMany()
           .HasForeignKey(i => i.StudentId)
           .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<InstructorStar>()
            .HasOne(i => i.Instructor)
            .WithMany()
            .HasForeignKey(i => i.InstructorId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<CourseComment>()
         .HasOne(i => i.Student)
         .WithMany()
         .HasForeignKey(i => i.StudentId)
         .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<CourseComment>()
            .HasOne(i => i.Course)
            .WithMany()
            .HasForeignKey(i => i.CourseId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<LessonComment>()
            .HasOne(i => i.User)
            .WithMany()
            .HasForeignKey(i => i.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<LessonComment>()
            .HasOne(i => i.Lesson)
            .WithMany()
            .HasForeignKey(i => i.LessonId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<CourseStars>()
           .HasOne(i => i.Student)
           .WithMany()
           .HasForeignKey(i => i.StudentId)
           .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<CourseStars>()
            .HasOne(i => i.Course)
            .WithMany()
            .HasForeignKey(i => i.CourseId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<StudentCourse>()
          .HasOne(i => i.Student)
          .WithMany()
          .HasForeignKey(i => i.StudentId)
          .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<StudentCourse>()
            .HasOne(i => i.Course)
            .WithMany()
            .HasForeignKey(i => i.CourseId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<QuizApplication>()
             .HasOne(i => i.Student)
             .WithMany()
             .HasForeignKey(i => i.StudentId)
             .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<QuizApplication>()
            .HasOne(i => i.Quiz)
            .WithMany()
            .HasForeignKey(i => i.QuizId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<QuizQuestion>()
            .HasOne(i => i.Quiz)
            .WithMany()
            .HasForeignKey(i => i.QuizId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<QuizQuestion>()
            .HasOne(i => i.Question)
            .WithMany()
            .HasForeignKey(i => i.QuestionId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Lesson>()
            .HasOne(l => l.Module)
            .WithMany()
            .HasForeignKey(l => l.ModuleId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
