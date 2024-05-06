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
using Arcana.Domain.Entities.Questions;
using Arcana.Domain.Entities.QuizApplications;
using Arcana.Domain.Entities.QuizQuestions;
using Arcana.Domain.Entities.Quizzes;
using Arcana.Domain.Entities.StudentCourses;
using Arcana.Domain.Entities.Students;
using Arcana.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
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
    private IDbContextTransaction transaction;
    public UnitOfWork(AppDbContext context)
    {
        this.context = context;
        Users = new Repository<User>(this.context);
        Assets = new Repository<Asset>(this.context);
        Students = new Repository<Student>(this.context);
        UserRoles = new Repository<UserRole>(this.context);
        Instructors = new Repository<Instructor>(this.context);
        Permissions = new Repository<Permission>(this.context);
        RolePermissions = new Repository<RolePermission>(this.context);


        Users = new Repository<User> Users(this.context);
        Assets = new Repository<Asset> Assets(this.context);
        Quizzes = new Repository<Quiz> Quizzes(this.context);
        Lessons = new Repository<Lesson> Lessons(this.context);
        Courses = new Repository<Course> Courses(this.context);
        UserRoles = new Repository<UserRole> UserRoles(this.context);
        Students = new Repository<Student> Students(this.context);
        Languages = new Repository<Language> Languages(this.context);
        Questions = new Repository<Question> Questions(this.context);
        Instructors = new Repository<Instructor> Instructors(this.context);
        Permissions = new Repository<Permission> Permissions(this.context);
        CourseStars = new Repository<CourseStars> CourseStars(this.context);
        CourseModules = new Repository<CourseModul> CourseModules(this.context);
        QuizQuestions = new Repository<QuizQuestion> QuizQuestions(this.context);
        CourseComments = new Repository<CourseComment> CourseComments(this.context);
        LessonComments = new Repository<LessonComment> LessonComments(this.context);
        StudentCourses = new Repository<StudentCourses> StudentCourses(this.context);
        QuestionAnswers = new Repository<QuestionAnswer> QuestionAnswers(this.context);
        RolePermissions = new Repository<RolePermission> RolePermissions(this.context);
        CourseCategories = new Repository<CourseCategory> CourseCategories(this.context);
        InstructorStars = new Repository<InstructorStars> InstructorStars(this.context);
        QuizApplications = new Repository<QuizApplication> QuizApplications(this.context);
        InstructorComments = new Repository<InstructorComment> InstructorComments(this.context);
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
