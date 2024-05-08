﻿using Arcana.DataAccess.Repositories;
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
    IRepository<CourseModule> CourseModules { get; }
    IRepository<QuizQuestion> QuizQuestions { get; }
    IRepository<CourseComment> CourseComments { get; }
    IRepository<LessonComment> LessonComments { get; }
    IRepository<StudentCourse> StudentCourses { get; }
    IRepository<QuestionAnswer> QuestionAnswers { get; }
    IRepository<RolePermission> RolePermissions { get; }
    IRepository<CourseCategory> CourseCategories { get; }
    IRepository<InstructorStar> InstructorStars { get; }
    IRepository<QuizApplication> QuizApplications { get; }
    IRepository<InstructorComment> InstructorComments { get; }
    ValueTask<bool> SaveAsync();
    ValueTask BeginTransactionAsync();
    ValueTask CommitTransactionAsync();
}