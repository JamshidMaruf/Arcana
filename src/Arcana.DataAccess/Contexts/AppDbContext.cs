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
        modelBuilder.Entity<InstructorStar>()
            .HasOne(instructorStar => instructorStar.Student)
            .WithMany()
            .HasForeignKey(instructorStar => instructorStar.StudentId)
            .OnDelete(DeleteBehavior.NoAction);

        // InstructorStar and Instructor
        modelBuilder.Entity<InstructorStar>()
            .HasOne(instructorStar => instructorStar.Instructor)
            .WithMany(instructor => instructor.Stars)
            .HasForeignKey(instructorStar => instructorStar.InstructorId)
            .OnDelete(DeleteBehavior.Restrict);

        // InstructorComment and Student
        modelBuilder.Entity<InstructorComment>()
            .HasOne(instructorComment => instructorComment.Student)
            .WithMany()
            .HasForeignKey(instructorComment => instructorComment.StudentId)
            .OnDelete(DeleteBehavior.NoAction);

        // InstructorComment and Instructor
        modelBuilder.Entity<InstructorComment>()
            .HasOne(instructorComment => instructorComment.Instructor)
            .WithMany(instructor => instructor.Comments)
            .HasForeignKey(instructorComment => instructorComment.InstructorId)
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

        // QuestionOption and Question
        modelBuilder.Entity<QuestionOption>()
            .HasOne(questionOption => questionOption.Question)
            .WithMany(question => question.Options)
            .HasForeignKey(questionOption => questionOption.QuestionId);

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
        modelBuilder.Entity<QuestionOption>()
            .HasOne(questionAnswer => questionAnswer.Question)
            .WithMany(question => question.Options)
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

        modelBuilder.Entity<QuestionAnswer>()
             .HasOne(quizApplication => quizApplication.Question)
             .WithMany()
             .HasForeignKey(quizApplication => quizApplication.QuestionId)
             .OnDelete(DeleteBehavior.NoAction);

        // QuizApplication and Quiz
        modelBuilder.Entity<QuestionAnswer>()
            .HasOne(quizApplication => quizApplication.Quiz)
            .WithMany()
            .HasForeignKey(quizApplication => quizApplication.QuizId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<QuestionAnswer>()
            .HasOne(quizApplication => quizApplication.Student)
            .WithMany()
            .HasForeignKey(quizApplication => quizApplication.StudentId)
            .OnDelete(DeleteBehavior.Restrict);
        #endregion


        #region SeedData
        // Permission
        modelBuilder.Entity<Permission>().HasData(
                new Permission { Id = 1, Action = "Post", Controller = "Students", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 2, Action = "Put", Controller = "Students", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 3, Action = "Delete", Controller = "Students", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 4, Action = "Get", Controller = "Students", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 5, Action = "Get", Controller = "Students", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 6, Action = "UploadPicture", Controller = "Students", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 7, Action = "DeletePicture", Controller = "Students", CreatedAt = DateTime.UtcNow },

                new Permission { Id = 8, Action = "Post", Controller = "Instructors", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 9, Action = "Put", Controller = "Instructors", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 10, Action = "Delete", Controller = "Instructors", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 11, Action = "Get", Controller = "Instructors", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 12, Action = "Get", Controller = "Instructors", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 13, Action = "UploadPicture", Controller = "Instructors", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 14, Action = "DeletePicture", Controller = "Instructors", CreatedAt = DateTime.UtcNow },

                new Permission { Id = 15, Action = "Post", Controller = "Users", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 16, Action = "Put", Controller = "Users", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 17, Action = "Delete", Controller = "Users", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 18, Action = "Get", Controller = "Users", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 19, Action = "Get", Controller = "Users", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 20, Action = "ChangePassword", Controller = "Users", CreatedAt = DateTime.UtcNow },

                new Permission { Id = 21, Action = "Post", Controller = "Lessons", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 22, Action = "Put", Controller = "Lessons", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 23, Action = "Delete", Controller = "Lessons", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 24, Action = "Get", Controller = "Lessons", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 25, Action = "Get", Controller = "Lessons", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 26, Action = "UploadPicture", Controller = "Lessons", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 27, Action = "DeletePicture", Controller = "Lessons", CreatedAt = DateTime.UtcNow },

                new Permission { Id = 28, Action = "Post", Controller = "Courses", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 29, Action = "Put", Controller = "Courses", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 30, Action = "Delete", Controller = "Courses", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 31, Action = "Get", Controller = "Courses", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 32, Action = "Get", Controller = "Courses", CreatedAt = DateTime.UtcNow },

                new Permission { Id = 33, Action = "Post", Controller = "UserRoles", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 34, Action = "Put", Controller = "UserRoles", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 35, Action = "Delete", Controller = "UserRoles", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 36, Action = "Get", Controller = "UserRoles", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 37, Action = "Get", Controller = "UserRoles", CreatedAt = DateTime.UtcNow },

                new Permission { Id = 38, Action = "Post", Controller = "Permissions", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 39, Action = "Put", Controller = "Permissions", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 40, Action = "Delete", Controller = "Permissions", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 41, Action = "Get", Controller = "Permissions", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 42, Action = "Get", Controller = "Permissions", CreatedAt = DateTime.UtcNow },

                new Permission { Id = 43, Action = "Post", Controller = "StudentCourses", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 44, Action = "Put", Controller = "StudentCourses", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 45, Action = "Delete", Controller = "StudentCourses", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 46, Action = "Get", Controller = "StudentCourses", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 47, Action = "Get", Controller = "StudentCourses", CreatedAt = DateTime.UtcNow },

                new Permission { Id = 48, Action = "Post", Controller = "Quizzes", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 49, Action = "Put", Controller = "Quizzes", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 50, Action = "Delete", Controller = "Quizzes", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 51, Action = "Get", Controller = "Quizzes", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 52, Action = "Get", Controller = "Quizzes", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 53, Action = "GenerateQuestions", Controller = "Quizzes", CreatedAt = DateTime.UtcNow },

                new Permission { Id = 54, Action = "Post", Controller = "QuizQuestions", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 55, Action = "Put", Controller = "QuizQuestions", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 56, Action = "Delete", Controller = "QuizQuestions", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 57, Action = "Get", Controller = "QuizQuestions", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 58, Action = "Get", Controller = "QuizQuestions", CreatedAt = DateTime.UtcNow },

                new Permission { Id = 59, Action = "Post", Controller = "QuizApplications", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 60, Action = "Put", Controller = "QuizApplications", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 61, Action = "Delete", Controller = "QuizApplications", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 62, Action = "Get", Controller = "QuizApplications", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 63, Action = "Get", Controller = "QuizApplications", CreatedAt = DateTime.UtcNow },

                new Permission { Id = 64, Action = "Post", Controller = "Questions", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 65, Action = "Put", Controller = "Questions", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 66, Action = "Delete", Controller = "Questions", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 67, Action = "Get", Controller = "Questions", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 68, Action = "Get", Controller = "Questions", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 69, Action = "UploadPicture", Controller = "Questions", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 70, Action = "DeletePicture", Controller = "Questions", CreatedAt = DateTime.UtcNow },

                new Permission { Id = 71, Action = "Post", Controller = "UserRoles", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 72, Action = "Put", Controller = "UserRoles", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 73, Action = "Delete", Controller = "UserRoles", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 74, Action = "Get", Controller = "UserRoles", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 75, Action = "Get", Controller = "UserRoles", CreatedAt = DateTime.UtcNow },

                new Permission { Id = 76, Action = "Post", Controller = "QuestionOptions", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 77, Action = "Put", Controller = "QuestionOptions", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 78, Action = "Delete", Controller = "QuestionOptions", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 79, Action = "Get", Controller = "QuestionOptions", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 80, Action = "Get", Controller = "QuestionOptions", CreatedAt = DateTime.UtcNow },

                new Permission { Id = 81, Action = "Post", Controller = "QuestionAnswers", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 82, Action = "Put", Controller = "QuestionAnswers", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 83, Action = "Delete", Controller = "QuestionAnswers", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 84, Action = "Get", Controller = "QuestionAnswers", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 85, Action = "Get", Controller = "QuestionAnswers", CreatedAt = DateTime.UtcNow },

                new Permission { Id = 86, Action = "Post", Controller = "LessonComments", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 87, Action = "Put", Controller = "LessonComments", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 88, Action = "Delete", Controller = "LessonComments", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 89, Action = "Get", Controller = "LessonComments", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 90, Action = "Get", Controller = "LessonComments", CreatedAt = DateTime.UtcNow },

                new Permission { Id = 91, Action = "Post", Controller = "Languages", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 92, Action = "Put", Controller = "Languages", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 93, Action = "Delete", Controller = "Languages", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 94, Action = "Get", Controller = "Languages", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 95, Action = "Get", Controller = "Languages", CreatedAt = DateTime.UtcNow },

                new Permission { Id = 96, Action = "Post", Controller = "InstructorStars", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 97, Action = "Put", Controller = "InstructorStars", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 98, Action = "Delete", Controller = "InstructorStars", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 99, Action = "Get", Controller = "InstructorStars", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 100, Action = "Get", Controller = "InstructorStars", CreatedAt = DateTime.UtcNow },

                new Permission { Id = 101, Action = "Post", Controller = "InstructorComments", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 102, Action = "Put", Controller = "InstructorComments", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 103, Action = "Delete", Controller = "InstructorComments", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 104, Action = "Get", Controller = "InstructorComments", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 105, Action = "Get", Controller = "InstructorComments", CreatedAt = DateTime.UtcNow },

                new Permission { Id = 106, Action = "Post", Controller = "RolePermissions", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 107, Action = "Put", Controller = "RolePermissions", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 108, Action = "Delete", Controller = "RolePermissions", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 109, Action = "Get", Controller = "RolePermissions", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 110, Action = "Get", Controller = "RolePermissions", CreatedAt = DateTime.UtcNow },

                new Permission { Id = 111, Action = "Post", Controller = "CourseModules", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 112, Action = "Put", Controller = "CourseModules", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 113, Action = "Delete", Controller = "CourseModules", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 114, Action = "Get", Controller = "CourseModules", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 115, Action = "Get", Controller = "CourseModules", CreatedAt = DateTime.UtcNow },

                new Permission { Id = 116, Action = "Post", Controller = "CourseStars", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 117, Action = "Put", Controller = "CourseStars", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 118, Action = "Delete", Controller = "CourseStars", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 119, Action = "Get", Controller = "CourseStars", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 120, Action = "Get", Controller = "CourseStars", CreatedAt = DateTime.UtcNow },

                new Permission { Id = 121, Action = "Login", Controller = "Accounts", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 122, Action = "SendCode", Controller = "Accounts", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 123, Action = "Confirm", Controller = "Accounts", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 124, Action = "ResetPassword", Controller = "Accounts", CreatedAt = DateTime.UtcNow },

                new Permission { Id = 125, Action = "Post", Controller = "CourseComments", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 126, Action = "Put", Controller = "CourseComments", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 127, Action = "Delete", Controller = "CourseComments", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 128, Action = "Get", Controller = "CourseComments", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 129, Action = "Get", Controller = "CourseComments", CreatedAt = DateTime.UtcNow },

                new Permission { Id = 130, Action = "Post", Controller = "CourseCategories", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 131, Action = "Put", Controller = "CourseCategories", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 132, Action = "Delete", Controller = "CourseCategories", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 133, Action = "Get", Controller = "CourseCategories", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 134, Action = "Get", Controller = "CourseCategories", CreatedAt = DateTime.UtcNow }
            );

        // UserRole
        modelBuilder.Entity<UserRole>().HasData(
            new UserRole { Id = 1, Name = "Admin", CreatedAt = DateTime.UtcNow },
            new UserRole { Id = 2, Name = "Student", CreatedAt = DateTime.UtcNow },
            new UserRole { Id = 3, Name = "Instructor", CreatedAt = DateTime.UtcNow });

        // CourseCategory
        modelBuilder.Entity<CourseCategory>().HasData(
            new CourseCategory() { Id = 1, Name = "IT", CreatedAt = DateTime.UtcNow });

        // Language
        modelBuilder.Entity<Language>().HasData(
                new Language { Id = 1, Name = "English", ShortName = "EN", CreatedAt = DateTime.UtcNow },
                new Language { Id = 2, Name = "Spanish", ShortName = "ES", CreatedAt = DateTime.UtcNow });

        // RolePermission
        modelBuilder.Entity<RolePermission>().HasData(
            new RolePermission() { Id = 1, RoleId = 1, PermissionId = 1, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 2, RoleId = 1, PermissionId = 2, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 3, RoleId = 1, PermissionId = 3, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 4, RoleId = 1, PermissionId = 4, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 5, RoleId = 1, PermissionId = 5, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 6, RoleId = 1, PermissionId = 6, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 7, RoleId = 1, PermissionId = 7, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 8, RoleId = 1, PermissionId = 8, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 9, RoleId = 1, PermissionId = 9, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 10, RoleId = 1, PermissionId = 10, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 11, RoleId = 1, PermissionId = 11, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 12, RoleId = 1, PermissionId = 12, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 13, RoleId = 1, PermissionId = 13, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 14, RoleId = 1, PermissionId = 14, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 15, RoleId = 1, PermissionId = 15, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 16, RoleId = 1, PermissionId = 16, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 17, RoleId = 1, PermissionId = 17, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 18, RoleId = 1, PermissionId = 18, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 19, RoleId = 1, PermissionId = 19, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 20, RoleId = 1, PermissionId = 20, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 21, RoleId = 1, PermissionId = 21, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 22, RoleId = 1, PermissionId = 22, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 23, RoleId = 1, PermissionId = 23, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 24, RoleId = 1, PermissionId = 24, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 25, RoleId = 1, PermissionId = 25, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 26, RoleId = 1, PermissionId = 26, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 27, RoleId = 1, PermissionId = 27, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 28, RoleId = 1, PermissionId = 28, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 29, RoleId = 1, PermissionId = 29, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 30, RoleId = 1, PermissionId = 30, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 31, RoleId = 1, PermissionId = 31, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 32, RoleId = 1, PermissionId = 32, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 33, RoleId = 1, PermissionId = 33, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 34, RoleId = 1, PermissionId = 34, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 35, RoleId = 1, PermissionId = 35, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 36, RoleId = 1, PermissionId = 36, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 37, RoleId = 1, PermissionId = 37, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 38, RoleId = 1, PermissionId = 38, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 39, RoleId = 1, PermissionId = 39, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 40, RoleId = 1, PermissionId = 40, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 41, RoleId = 1, PermissionId = 41, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 42, RoleId = 1, PermissionId = 42, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 43, RoleId = 1, PermissionId = 43, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 44, RoleId = 1, PermissionId = 44, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 45, RoleId = 1, PermissionId = 45, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 46, RoleId = 1, PermissionId = 46, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 47, RoleId = 1, PermissionId = 47, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 48, RoleId = 1, PermissionId = 48, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 49, RoleId = 1, PermissionId = 49, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 50, RoleId = 1, PermissionId = 50, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 51, RoleId = 1, PermissionId = 51, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 52, RoleId = 1, PermissionId = 52, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 53, RoleId = 1, PermissionId = 53, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 54, RoleId = 1, PermissionId = 54, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 55, RoleId = 1, PermissionId = 55, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 56, RoleId = 1, PermissionId = 56, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 57, RoleId = 1, PermissionId = 57, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 58, RoleId = 1, PermissionId = 58, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 59, RoleId = 1, PermissionId = 59, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 60, RoleId = 1, PermissionId = 60, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 61, RoleId = 1, PermissionId = 61, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 62, RoleId = 1, PermissionId = 62, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 63, RoleId = 1, PermissionId = 63, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 64, RoleId = 1, PermissionId = 64, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 65, RoleId = 1, PermissionId = 65, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 66, RoleId = 1, PermissionId = 66, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 67, RoleId = 1, PermissionId = 67, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 68, RoleId = 1, PermissionId = 68, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 69, RoleId = 1, PermissionId = 69, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 70, RoleId = 1, PermissionId = 70, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 71, RoleId = 1, PermissionId = 71, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 72, RoleId = 1, PermissionId = 72, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 73, RoleId = 1, PermissionId = 73, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 74, RoleId = 1, PermissionId = 74, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 75, RoleId = 1, PermissionId = 75, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 76, RoleId = 1, PermissionId = 76, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 77, RoleId = 1, PermissionId = 77, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 78, RoleId = 1, PermissionId = 78, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 79, RoleId = 1, PermissionId = 79, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 80, RoleId = 1, PermissionId = 80, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 81, RoleId = 1, PermissionId = 81, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 82, RoleId = 1, PermissionId = 82, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 83, RoleId = 1, PermissionId = 83, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 84, RoleId = 1, PermissionId = 84, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 85, RoleId = 1, PermissionId = 85, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 86, RoleId = 1, PermissionId = 86, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 87, RoleId = 1, PermissionId = 87, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 88, RoleId = 1, PermissionId = 88, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 89, RoleId = 1, PermissionId = 89, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 90, RoleId = 1, PermissionId = 90, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 91, RoleId = 1, PermissionId = 91, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 92, RoleId = 1, PermissionId = 92, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 93, RoleId = 1, PermissionId = 93, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 94, RoleId = 1, PermissionId = 94, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 95, RoleId = 1, PermissionId = 95, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 96, RoleId = 1, PermissionId = 96, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 97, RoleId = 1, PermissionId = 97, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 98, RoleId = 1, PermissionId = 98, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 99, RoleId = 1, PermissionId = 99, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 100, RoleId = 1, PermissionId = 100, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 101, RoleId = 1, PermissionId = 101, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 102, RoleId = 1, PermissionId = 102, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 103, RoleId = 1, PermissionId = 103, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 104, RoleId = 1, PermissionId = 104, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 105, RoleId = 1, PermissionId = 105, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 106, RoleId = 1, PermissionId = 106, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 107, RoleId = 1, PermissionId = 107, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 108, RoleId = 1, PermissionId = 108, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 109, RoleId = 1, PermissionId = 109, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 110, RoleId = 1, PermissionId = 110, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 111, RoleId = 1, PermissionId = 111, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 112, RoleId = 1, PermissionId = 112, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 113, RoleId = 1, PermissionId = 113, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 114, RoleId = 1, PermissionId = 114, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 115, RoleId = 1, PermissionId = 115, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 116, RoleId = 1, PermissionId = 116, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 117, RoleId = 1, PermissionId = 117, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 118, RoleId = 1, PermissionId = 118, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 119, RoleId = 1, PermissionId = 119, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 120, RoleId = 1, PermissionId = 120, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 121, RoleId = 1, PermissionId = 121, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 122, RoleId = 1, PermissionId = 122, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 123, RoleId = 1, PermissionId = 123, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 124, RoleId = 1, PermissionId = 124, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 125, RoleId = 1, PermissionId = 125, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 126, RoleId = 1, PermissionId = 126, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 127, RoleId = 1, PermissionId = 127, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 128, RoleId = 1, PermissionId = 128, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 129, RoleId = 1, PermissionId = 129, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 130, RoleId = 1, PermissionId = 130, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 131, RoleId = 1, PermissionId = 131, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 132, RoleId = 1, PermissionId = 132, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 133, RoleId = 1, PermissionId = 133, CreatedAt = DateTime.UtcNow },
            new RolePermission() { Id = 134, RoleId = 1, PermissionId = 134, CreatedAt = DateTime.UtcNow }
            );

        // User
        modelBuilder.Entity<User>().HasData(
            new User()
            {
                Id = 1,
                FirstName = "FirstName1",
                LastName = "LastName1",
                Email = "Email1@gmail.com",
                Password = "Password1",
                Phone = "+998991111111",
                DateOfBirth = new DateTime(2001, 1, 1),
                RoleId = 1,
                CreatedAt = DateTime.UtcNow
            },
            new User()
            {
                Id = 2,
                FirstName = "FirstName2",
                LastName = "LastName2",
                Email = "Email2@gmail.com",
                Password = "Password2",
                Phone = "+998992222222",
                DateOfBirth = new DateTime(2002, 2, 2),
                RoleId = 2,
                CreatedAt = DateTime.UtcNow
            },
            new User()
            {
                Id = 3,
                FirstName = "FirstName3",
                LastName = "LastName3",
                Email = "Email3@gmail.com",
                Password = "Password3",
                Phone = "+998993333333",
                DateOfBirth = new DateTime(2003, 3, 3),
                RoleId = 3,
                CreatedAt = DateTime.UtcNow
            });

        // Asset
        modelBuilder.Entity<Asset>().HasData(
            new Asset() { Id = 1, Name = "Picture", Path = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.vecteezy.com%2Ffree-photos%2Fpicture&psig=AOvVaw3XaUHI9Jhqr2Yekc8F0A7X&ust=1715337265006000&source=images&cd=vfe&opi=89978449&ved=0CBIQjRxqFwoTCNjGn7WvgIYDFQAAAAAdAAAAABAE", CreatedAt = DateTime.UtcNow },
            new Asset() { Id = 2, Name = "Picture2", Path = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.vecteezy.com%2Ffree-photos%2Fpicture&psig=AOvVaw3XaUHI9Jhqr2Yekc8F0A7X&ust=1715337265006000&source=images&cd=vfe&opi=89978449&ved=0CBIQjRxqFwoTCNjGn7WvgIYDFQAAAAAdAAAAABAE", CreatedAt = DateTime.UtcNow });

        // Course
        modelBuilder.Entity<Course>().HasData(
            new Course
            {
                Id = 1,
                Name = ".NET",
                Description = "Course Description",
                Price = 2200000.00m,
                Duration = 7,
                CountOfLessons = 150,
                Level = Level.Advanced,
                CategoryId = 1,
                InstructorId = 1,
                FileId = 1,
                LanguageId = 1,
                CreatedAt = DateTime.UtcNow
            });

        // Student
        modelBuilder.Entity<Student>().HasData(
            new Student() { Id = 1, DetailId = 2, PictureId = 1, CreatedAt = DateTime.UtcNow });

        // StudentCourse
        modelBuilder.Entity<StudentCourse>().HasData(
            new StudentCourse() { Id = 1, CourseId = 1, StudentId = 1, CreatedAt = DateTime.UtcNow });

        // CoursesComment
        modelBuilder.Entity<CourseComment>().HasData(
            new CourseComment() { Id = 1, Content = "Course Comment", StudentId = 1, CourseId = 1, CreatedAt = DateTime.UtcNow });

        // CourseModule
        modelBuilder.Entity<CourseModule>().HasData(
            new CourseModule() { Id = 1, Name = "Module1", CourseId = 1, CreatedAt = DateTime.UtcNow });

        // CourseStars
        modelBuilder.Entity<CourseStars>().HasData(
            new CourseStars() { Id = 1, StudentId = 1, CourseId = 1, Stars = 5, CreatedAt = DateTime.UtcNow });

        // Lesson
        modelBuilder.Entity<Lesson>().HasData(
            new Lesson() { Id = 1, Title = "Lesson1", Description = "Lesson Description", FileId = 2, ModuleId = 1, CreatedAt = DateTime.UtcNow });

        // LessonComment
        modelBuilder.Entity<LessonComment>().HasData(
            new LessonComment() { Id = 1, LessonId = 1, Content = "Lesson Comment", UserId = 2, CreatedAt = DateTime.UtcNow });

        // Instructor
        modelBuilder.Entity<Instructor>().HasData(
            new Instructor() { Id = 1, Profession = "Software Developer", About = "Description", DetailId = 3, PictureId = 2, CreatedAt = DateTime.UtcNow });

        // InstructorStars
        modelBuilder.Entity<InstructorStar>().HasData(
            new InstructorStar() { Id = 1, Stars = 5, StudentId = 1, InstructorId = 1, CreatedAt = DateTime.UtcNow });

        // InstructorComment
        modelBuilder.Entity<InstructorComment>().HasData(
            new InstructorComment() { Id = 1, StudentId = 1, InstructorId = 1, CreatedAt = DateTime.UtcNow });

        // Quiz
        modelBuilder.Entity<Quiz>().HasData(new Quiz() { Id = 1, Name = "Quiz1", QuestionCount = 5, ModuleId = 1, CreatedAt = DateTime.UtcNow });

        // QuizApplication
        modelBuilder.Entity<QuizApplication>().HasData(new QuizApplication() { Id = 1, QuizId = 1, StudentId = 1, StartTime = new DateTime(2024, 10, 8, 10, 0, 0), EndTime = new DateTime(2024, 11, 8, 10, 0, 0), CreatedAt = DateTime.UtcNow });

        // Question
        modelBuilder.Entity<Question>().HasData(new Question() { Id = 1, Content = "Content", FileId = 2, ModuleId = 1, CreatedAt = DateTime.UtcNow });

        // QuizOption
        modelBuilder.Entity<QuestionOption>().HasData(
            new QuestionOption() { Id = 1, Content = "asd", QuestionId = 1, IsCorrect = true, CreatedAt = DateTime.UtcNow },
            new QuestionOption() { Id = 2, Content = "dsd", QuestionId = 1, IsCorrect = false, CreatedAt = DateTime.UtcNow },
            new QuestionOption() { Id = 3, Content = "bdb", QuestionId = 1, IsCorrect = false, CreatedAt = DateTime.UtcNow },
            new QuestionOption() { Id = 4, Content = "waw", QuestionId = 1, IsCorrect = false, CreatedAt = DateTime.UtcNow });

        // QuizAnswer
        modelBuilder.Entity<QuestionAnswer>().HasData(
            new QuestionAnswer() { Id = 1, QuizId = 1, StudentId = 1, QuestionId = 1, OptionId = 1, CreatedAt = DateTime.UtcNow });

        // QuizQuestion
        modelBuilder.Entity<QuizQuestion>().HasData(new QuizQuestion() { Id = 1, QuestionId = 1, QuizId = 1, CreatedAt = DateTime.UtcNow });

        #endregion
    }
}