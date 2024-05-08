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
using Arcana.WebApi.Models.Assets;
using Arcana.WebApi.Models.CourseCategories;
using Arcana.WebApi.Models.CourseComments;
using Arcana.WebApi.Models.CourseModules;
using Arcana.WebApi.Models.Courses;
using Arcana.WebApi.Models.CourseStars;
using Arcana.WebApi.Models.InstructorComments;
using Arcana.WebApi.Models.Instructors;
using Arcana.WebApi.Models.InstructorStars;
using Arcana.WebApi.Models.Languages;
using Arcana.WebApi.Models.LessonComments;
using Arcana.WebApi.Models.Lessons;
using Arcana.WebApi.Models.Permissions;
using Arcana.WebApi.Models.QuestionAnswers;
using Arcana.WebApi.Models.Questions;
using Arcana.WebApi.Models.QuizApplications;
using Arcana.WebApi.Models.QuizQuestions;
using Arcana.WebApi.Models.Quizzes;
using Arcana.WebApi.Models.RolePermissions;
using Arcana.WebApi.Models.StudentCourses;
using Arcana.WebApi.Models.Students;
using Arcana.WebApi.Models.UserRoles;
using Arcana.WebApi.Models.Users;
using AutoMapper;

namespace Arcana.WebApi.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AssetViewModel, Asset>().ReverseMap();

        CreateMap<InstructorViewModel, Instructor>().ReverseMap();
        CreateMap<Instructor, InstructorCreateModel>().ReverseMap();
        CreateMap<Instructor, InstructorUpdateModel>().ReverseMap();

        CreateMap<PermissionViewModel, Permission>().ReverseMap();
        CreateMap<Permission, PermissionCreateModel>().ReverseMap();
        CreateMap<Permission, PermissionUpdateModel>().ReverseMap();

        CreateMap<RolePermissionViewModel, RolePermission>().ReverseMap();
        CreateMap<RolePermission, RolePermissionCreateModel>().ReverseMap();

        CreateMap<StudentViewModel, Student>().ReverseMap();
        CreateMap<Student, StudentCreateModel>().ReverseMap();
        CreateMap<Student, StudentUpdateModel>().ReverseMap();

        CreateMap<UserRoleViewModel, UserRole>().ReverseMap();
        CreateMap<UserRole, UserRoleCreateModel>().ReverseMap();
        CreateMap<UserRole, UserRoleUpdateModel>().ReverseMap();

        CreateMap<UserViewModel, User>().ReverseMap();
        CreateMap<UserLoginViewModel, User>().ReverseMap();
        CreateMap<User, UserCreateModel>().ReverseMap();
        CreateMap<User, UserUpdateModel>().ReverseMap();

        CreateMap<CourseCategoryViewModel, CourseCategory>().ReverseMap();
        CreateMap<CourseCategory, CourseCategoryCreateModel>().ReverseMap();
        CreateMap<CourseCategory, CourseCategoryUpdateModel>().ReverseMap();

        CreateMap<CourseCommentViewModel, CourseComment>().ReverseMap();
        CreateMap<CourseComment, CourseCommentCreateModel>().ReverseMap();
        CreateMap<CourseComment, CourseCommentUpdateModel>().ReverseMap();

        CreateMap<CourseModuleViewModel, CourseModule>().ReverseMap();
        CreateMap<CourseModule, CourseModuleCreateModel>().ReverseMap();
        CreateMap<CourseModule, CourseModuleUpdateModel>().ReverseMap();

        CreateMap<CourseViewModel, Course>().ReverseMap();
        CreateMap<Course, CourseCreateModel>().ReverseMap();
        CreateMap<Course, CourseUpdateModel>().ReverseMap();

        CreateMap<CourseStarsViewModel, CourseStars>().ReverseMap();
        CreateMap<CourseStars, CourseStarsCreateModel>().ReverseMap();
        CreateMap<CourseStars, CourseStarsUpdateModel>().ReverseMap();

        CreateMap<InstructorCommentViewModel, InstructorComment>().ReverseMap();
        CreateMap<InstructorComment, InstructorCommentCreateModel>().ReverseMap();
        CreateMap<InstructorComment, InstructorCommentUpdateModel>().ReverseMap();

        CreateMap<InstructorStarsViewModel, InstructorStars>().ReverseMap();
        CreateMap<InstructorStars, InstructorStarsCreateModel>().ReverseMap();
        CreateMap<InstructorStars, InstructorStarsUpdateModel>().ReverseMap();

        CreateMap<LanguageViewModel, Language>().ReverseMap();
        CreateMap<Language, LanguageCreateModel>().ReverseMap();
        CreateMap<Language, LanguageUpdateModel>().ReverseMap();

        CreateMap<LessonViewModel, Lesson>().ReverseMap();
        CreateMap<Lesson, LessonCreateModel>().ReverseMap();
        CreateMap<Lesson, LessonUpdateModel>().ReverseMap();

        CreateMap<LessonCommentViewModel, LessonComment>().ReverseMap();
        CreateMap<LessonComment, LessonCommentCreateModel>().ReverseMap();
        CreateMap<LessonComment, LessonCommentUpdateModel>().ReverseMap();

        CreateMap<QuestionAnswerViewModel, QuestionAnswer>().ReverseMap();
        CreateMap<QuestionAnswer, QuestionAnswerCreateModel>().ReverseMap();
        CreateMap<QuestionAnswer, QuestionAnswerUpdateModel>().ReverseMap();

        CreateMap<QuestionViewModel, Question>().ReverseMap();
        CreateMap<Question, QuestionCreateModel>().ReverseMap();
        CreateMap<Question, QuestionUpdateModel>().ReverseMap();

        CreateMap<QuizApplicationViewModel, QuizApplication>().ReverseMap();
        CreateMap<QuizApplication, QuizApplicationCreateModel>().ReverseMap();
        CreateMap<QuizApplication, QuizApplicationUpdateModel>().ReverseMap();

        CreateMap<QuizQuestionViewModel, QuizQuestion>().ReverseMap();
        CreateMap<QuizApplication, QuizQuestionCreateModel>().ReverseMap();
        CreateMap<QuizApplication, QuizQuestionUpdateModel>().ReverseMap();

        CreateMap<QuizViewModel, Quiz>().ReverseMap();
        CreateMap<Quiz, QuizCreateModel>().ReverseMap();
        CreateMap<Quiz, QuizUpdateModel>().ReverseMap();

        CreateMap<StudentCourseViewModel, StudentCourse>().ReverseMap();
        CreateMap<StudentCourse, StudentCourseCreateModel>().ReverseMap();
        CreateMap<StudentCourse, StudentCourseUpdateModel>().ReverseMap();
    }
}
