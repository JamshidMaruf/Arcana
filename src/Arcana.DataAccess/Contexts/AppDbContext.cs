using Arcana.Domain.Entities.Commons;
using Arcana.Domain.Entities.CourseCategories;
using Arcana.Domain.Entities.CourseComments;
using Arcana.Domain.Entities.Courses;
using Arcana.Domain.Entities.Instructors;
using Arcana.Domain.Entities.Languages;
using Arcana.Domain.Entities.Lessons;
using Arcana.Domain.Entities.QuestionAnswer1;
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
    public DbSet<QuestionAnswer1> QuestionAnswers1 { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }
    public DbSet<CourseCategory> CourseCategories { get; set; }
    public DbSet<InstructorStars> InstructorStars { get; set; }
    public DbSet<QuizApplication> QuizApplications { get; set; }
    public DbSet<InstructorComment> InstructorComments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>()
            .Property(c => c.Price)
            .HasColumnType("decimal(18,3)");

        #region Fluent API relations

        // User and Role
        modelBuilder.Entity<User>()
            .HasOne(user => user.Role)
            .WithMany()
            .HasForeignKey(user => user.RoleId)
            .OnDelete(DeleteBehavior.Restrict);

        // RolePermission and Role
        modelBuilder.Entity<RolePermission>()
            .HasOne(rolePermission => rolePermission.Role)
            .WithMany()
            .HasForeignKey(rolePermission => rolePermission.RoleId)
            .OnDelete(DeleteBehavior.Cascade);

        // RolePermission and Permission
        modelBuilder.Entity<RolePermission>()
            .HasOne(rolePermission => rolePermission.Permission)
            .WithMany()
            .HasForeignKey(rolePermission => rolePermission.PermissionId)
            .OnDelete(DeleteBehavior.Cascade);

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

        // InstructorStar and Student
        modelBuilder.Entity<InstructorStars>()
            .HasOne(insturctorStar => insturctorStar.Student)
            .WithMany()
            .HasForeignKey(insturctorStar => insturctorStar.StudentId)
            .OnDelete(DeleteBehavior.NoAction);

        // InstructorStar and Instructor
        modelBuilder.Entity<InstructorStars>()
            .HasOne(insturctorStar => insturctorStar.Instructor)
            .WithMany(instructor => instructor.Stars)
            .HasForeignKey(insturctorStar => insturctorStar.InstructorId)
            .OnDelete(DeleteBehavior.Restrict);

        // InstructorComment and Student
        modelBuilder.Entity<InstructorComment>()
            .HasOne(insturactorComment => insturactorComment.Student)
            .WithMany()
            .HasForeignKey(insturactorComment => insturactorComment.StudentId)
            .OnDelete(DeleteBehavior.NoAction);

        // InstructorComment and Instructor
        modelBuilder.Entity<InstructorComment>()
            .HasOne(insturactorComment => insturactorComment.Instructor)
            .WithMany(instructor => instructor.Comments)
            .HasForeignKey(insturactorComment => insturactorComment.InstructorId)
            .OnDelete(DeleteBehavior.Restrict);

        // Course and CourseCategory
        modelBuilder.Entity<Course>()
            .HasOne(course => course.Category)
            .WithMany()
            .HasForeignKey(course => course.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        // Course and Instructor
        modelBuilder.Entity<Course>()
            .HasOne(course => course.Instructor)
            .WithMany(instructor => instructor.Courses)
            .HasForeignKey(course => course.InstructorId);

        // Course and Asset
        modelBuilder.Entity<Course>()
            .HasOne(course => course.File)
            .WithMany()
            .HasForeignKey(course => course.FileId);

        // Course and Language
        modelBuilder.Entity<Course>()
            .HasOne(course => course.Language)
            .WithMany()
            .HasForeignKey(course => course.LanguageId);

        // CourseModule and Course
        modelBuilder.Entity<CourseModule>()
            .HasOne(courseModule => courseModule.Course)
            .WithMany(course => course.Modules)
            .HasForeignKey(course => course.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

        // CourseStar and Student
        modelBuilder.Entity<CourseStars>()
            .HasOne(courseStar => courseStar.Student)
            .WithMany()
            .HasForeignKey(courseStar => courseStar.StudentId)
            .OnDelete(DeleteBehavior.NoAction);

        // CourseStar and Course
        modelBuilder.Entity<CourseStars>()
            .HasOne(courseStar => courseStar.Course)
            .WithMany(course => course.Stars)
            .HasForeignKey(courseStar => courseStar.CourseId)
            .OnDelete(DeleteBehavior.Restrict);

        // CourseComment and Student
        modelBuilder.Entity<CourseComment>()
            .HasOne(courseComment => courseComment.Student)
            .WithMany()
            .HasForeignKey(courseComment => courseComment.StudentId)
            .OnDelete(DeleteBehavior.NoAction);

        // CourseComment and Course
        modelBuilder.Entity<CourseComment>()
            .HasOne(courseComment => courseComment.Course)
            .WithMany(course => course.Comments)
            .HasForeignKey(courseComment => courseComment.CourseId)
            .OnDelete(DeleteBehavior.Restrict);

        // StudentCourse and Student
        modelBuilder.Entity<StudentCourse>()
            .HasOne(studentCourse => studentCourse.Student)
            .WithMany(student => student.Courses)
            .HasForeignKey(studentCourse => studentCourse.StudentId)
            .OnDelete(DeleteBehavior.NoAction);

        // StudentCourse and Course
        modelBuilder.Entity<StudentCourse>()
            .HasOne(studentCourse => studentCourse.Course)
            .WithMany()
            .HasForeignKey(studentCourse => studentCourse.CourseId)
            .OnDelete(DeleteBehavior.Restrict);

        // Lesson and Asset
        modelBuilder.Entity<Lesson>()
            .HasOne(lesson => lesson.File)
            .WithMany()
            .HasForeignKey(lesson => lesson.FileId);

        // Lesson and CourseModule
        modelBuilder.Entity<Lesson>()
            .HasOne(lesson => lesson.Module)
            .WithMany(module => module.Lessons)
            .HasForeignKey(lesson => lesson.ModuleId)
            .OnDelete(DeleteBehavior.NoAction);

        // LessonComment and User
        modelBuilder.Entity<LessonComment>()
            .HasOne(lessonComment => lessonComment.User)
            .WithMany()
            .HasForeignKey(lessonComment => lessonComment.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        // LessonComment and Lesson
        modelBuilder.Entity<LessonComment>()
            .HasOne(lessonComment => lessonComment.Lesson)
            .WithMany(lesson => lesson.Comments)
            .HasForeignKey(lessonComment => lessonComment.LessonId)
            .OnDelete(DeleteBehavior.Restrict);

        // LessonComment and Parent
        modelBuilder.Entity<LessonComment>()
            .HasOne(lessonComment => lessonComment.Parent)
            .WithMany()
            .HasForeignKey(lessonComment => lessonComment.ParentId);

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

        // QuestionAnswer and Question
        modelBuilder.Entity<QuestionAnswer>()
            .HasOne(questionAnswer => questionAnswer.Question)
            .WithMany(question => question.Answers)
            .HasForeignKey(questionAnswer => questionAnswer.QuestionId);

        // Quiz and CourseModule
        modelBuilder.Entity<Quiz>()
            .HasOne(quiz => quiz.Module)
            .WithMany()
            .HasForeignKey(quiz => quiz.ModuleId);

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

        // Question and QuizAnswer
        modelBuilder.Entity<QuestionAnswer>()
            .HasOne(questionAnswer => questionAnswer.Question)
            .WithMany(question => question.Answers)
            .HasForeignKey(questionAnswer => questionAnswer.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);
            
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
        #endregion
    }
}