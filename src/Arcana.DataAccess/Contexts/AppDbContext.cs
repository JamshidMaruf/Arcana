using Arcana.DataAccess.EntityConfigurations.Commons;
using Arcana.Domain.Entities.Commons;
using Arcana.Domain.Entities.CourseCategories;
using Arcana.Domain.Entities.CourseComments;
using Arcana.Domain.Entities.Courses;
using Arcana.Domain.Entities.Instructors;
using Arcana.Domain.Entities.Languages;
using Arcana.Domain.Entities.Lessons;
using Arcana.Domain.Entities.QuestionAnswers;
using Arcana.Domain.Entities.QuestionOptions;
using Arcana.Domain.Entities.Questions;
using Arcana.Domain.Entities.QuizApplications;
using Arcana.Domain.Entities.QuizQuestions;
using Arcana.Domain.Entities.Quizzes;
using Arcana.Domain.Entities.StudentCourses;
using Arcana.Domain.Entities.Students;
using Arcana.Domain.Entities.Users;
using Arcana.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Arcana.DataAccess.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

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
    public DbSet<QuestionOption> QuestionOptions { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }
    public DbSet<CourseCategory> CourseCategories { get; set; }
    public DbSet<InstructorStar> InstructorStars { get; set; }
    public DbSet<QuizApplication> QuizApplications { get; set; }
    public DbSet<InstructorComment> InstructorComments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        ApplyConfigurations(modelBuilder);
    }

    private void ApplyConfigurations(ModelBuilder modelBuilder)
    {
        var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => !string.IsNullOrEmpty(type.Namespace))
            .Where(type => type.GetInterfaces().Any(inter => inter == typeof(IEntityConfiguration)));

        foreach (var type in typesToRegister)
        {
            var configuration = (IEntityConfiguration)Activator.CreateInstance(type);
            configuration.Configure(modelBuilder);
            configuration.SeedData(modelBuilder); // Call the SeedData method
        }
    }
}