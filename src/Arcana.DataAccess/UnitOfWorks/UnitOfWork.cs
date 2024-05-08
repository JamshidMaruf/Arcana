using Arcana.DataAccess.Contexts;
using Arcana.DataAccess.Repositories;
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
using Microsoft.EntityFrameworkCore.Storage;

namespace Arcana.DataAccess.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext context;
    public IRepository<User> Users { get; }
    public IRepository<Asset> Assets { get; }
    public IRepository<Student> Students { get; }
    public IRepository<UserRole> UserRoles { get; }
    public IRepository<Instructor> Instructors { get; }
    public IRepository<Permission> Permissions { get; }
    public IRepository<RolePermission> RolePermissions { get; }
    public IRepository<Quiz> Quizzes { get; }
    public IRepository<Lesson> Lessons { get; }
    public IRepository<Course> Courses { get; }
    public IRepository<Language> Languages { get; }
    public IRepository<Question> Questions { get; }
    public IRepository<CourseStars> CourseStars { get; }
    public IRepository<CourseModule> CourseModules { get; }
    public IRepository<QuizQuestion> QuizQuestions { get; }
    public IRepository<CourseComment> CourseComments { get; }
    public IRepository<LessonComment> LessonComments { get; }
    public IRepository<StudentCourse> StudentCourses { get; }
    public IRepository<QuestionAnswer> QuestionAnswers { get; }
    public IRepository<QuestionOption> QuestionOptions { get; }
    public IRepository<CourseCategory> CourseCategories { get; }
    public IRepository<InstructorStar> InstructorStars { get; }
    public IRepository<QuizApplication> QuizApplications { get; }
    public IRepository<InstructorComment> InstructorComments { get; }
    private IDbContextTransaction transaction;

    public UnitOfWork(AppDbContext context)
    {
        this.context = context;
        Users = new Repository<User>(this.context);
        Assets = new Repository<Asset>(this.context);
        Quizzes = new Repository<Quiz>(this.context);
        Lessons = new Repository<Lesson>(this.context);
        Courses = new Repository<Course>(this.context);
        UserRoles = new Repository<UserRole>(this.context);
        Students = new Repository<Student>(this.context);
        Languages = new Repository<Language>(this.context);
        Questions = new Repository<Question>(this.context);
        Instructors = new Repository<Instructor>(this.context);
        Permissions = new Repository<Permission>(this.context);
        CourseStars = new Repository<CourseStars>(this.context);
        CourseModules = new Repository<CourseModule>(this.context);
        QuizQuestions = new Repository<QuizQuestion>(this.context);
        CourseComments = new Repository<CourseComment>(this.context);
        LessonComments = new Repository<LessonComment>(this.context);
        StudentCourses = new Repository<StudentCourse>(this.context);
        QuestionOptions = new Repository<QuestionOption>(this.context);
        RolePermissions = new Repository<RolePermission>(this.context);
        CourseCategories = new Repository<CourseCategory>(this.context);
        InstructorStars = new Repository<InstructorStar>(this.context);
        QuizApplications = new Repository<QuizApplication>(this.context);
        InstructorComments = new Repository<InstructorComment>(this.context);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public async ValueTask<bool> SaveAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }

    public async ValueTask BeginTransactionAsync()
    {
        transaction = await this.context.Database.BeginTransactionAsync();
    }

    public async ValueTask CommitTransactionAsync()
    {
        await transaction.CommitAsync();
    }
}
