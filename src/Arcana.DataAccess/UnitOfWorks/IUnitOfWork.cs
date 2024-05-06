using Arcana.DataAccess.Repositories;
using Arcana.Domain.Entities.Commons;
using Arcana.Domain.Entities.CourseCategories;
using Arcana.Domain.Entities.CourseComments;
using Arcana.Domain.Entities.Courses;
using Arcana.Domain.Entities.Instructors;
using Arcana.Domain.Entities.Lessons;
using Arcana.Domain.Entities.Students;
using Arcana.Domain.Entities.Users;
using System.Reflection;

namespace Arcana.DataAccess.UnitOfWorks;

public interface IUnitOfWork : IDisposable
{
    IRepository<User> Users { get;}
    IRepository<Asset> Assets { get;}
    IRepository<Quiz> Quizzes { get; }
    IRepository<Lesson> Lessons { get; }
    IRepository<Course> Courses { get; }
    IRepository<UserRole> UserRoles { get; }
    IRepository<Student> Students { get; }
    IRepository<Language> Languages { get; }
    IRepository<Question> Questions { get; }
    IRepository<Instructor> Instructors { get; }
    IRepository<Permission> Permissions { get; }
    IRepository<CourseStars> CourseStars { get; }
    IRepository<CourseModul> CourseModules { get; }
    IRepository<QuizQuestion> QuizQuestions { get; }
    IRepository<CourseComment> CourseComments { get; }
    IRepository<LessonComment> LessonComments { get; }
    IRepository<StudentCourses> StudentCourses { get; }
    IRepository<QuestionAnswer> QuestionAnswers { get; }
    IRepository<RolePermission> RolePermissions { get; }
    IRepository<CourseCategory> CourseCategories { get; }
    IRepository<InstructorStars> InstructorStars { get; }
    IRepository<QuizApplication> QuizApplications { get; }
    IRepository<InstructorComment> InstructorComments { get; }
    ValueTask<bool> SaveAsync();
    ValueTask BeginTransactionAsync();
    ValueTask CommitTransactionAsync();
}