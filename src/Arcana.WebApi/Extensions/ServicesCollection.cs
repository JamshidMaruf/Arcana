using Arcana.DataAccess.UnitOfWorks;
using Arcana.Service.Helpers;
using Arcana.Service.Services.Assets;
using Arcana.Service.Services.CourseCategories;
using Arcana.Service.Services.CourseComments;
using Arcana.Service.Services.CourseModules;
using Arcana.Service.Services.Courses;
using Arcana.Service.Services.InstructorComments;
using Arcana.Service.Services.Instructors;
using Arcana.Service.Services.Languages;
using Arcana.Service.Services.LessonComments;
using Arcana.Service.Services.Lessons;
using Arcana.Service.Services.Permissions;
using Arcana.Service.Services.QuestionOptions;
using Arcana.Service.Services.Questions;
using Arcana.Service.Services.QuizApplications;
using Arcana.Service.Services.QuizQuestions;
using Arcana.Service.Services.Quizzes;
using Arcana.Service.Services.RolePermissions;
using Arcana.Service.Services.StudentCourses;
using Arcana.Service.Services.Students;
using Arcana.Service.Services.UserRoles;
using Arcana.Service.Services.Users;
using Arcana.WebApi.ApiServices.Accounts;
using Arcana.WebApi.ApiServices.CourseCategories;
using Arcana.WebApi.ApiServices.CourseComments;
using Arcana.WebApi.ApiServices.CourseModules;
using Arcana.WebApi.ApiServices.Courses;
using Arcana.WebApi.ApiServices.InstructorComments;
using Arcana.WebApi.ApiServices.Instructors;
using Arcana.WebApi.ApiServices.InstructorStars;
using Arcana.WebApi.ApiServices.Languages;
using Arcana.WebApi.ApiServices.LessonComments;
using Arcana.WebApi.ApiServices.Lessons;
using Arcana.WebApi.ApiServices.Permissions;
using Arcana.WebApi.ApiServices.QuestionOptions;
using Arcana.WebApi.ApiServices.Questions;
using Arcana.WebApi.ApiServices.QuizApplications;
using Arcana.WebApi.ApiServices.QuizQuestions;
using Arcana.WebApi.ApiServices.RolePermissions;
using Arcana.WebApi.ApiServices.StudentCourses;
using Arcana.WebApi.ApiServices.Students;
using Arcana.WebApi.ApiServices.UserRoles;
using Arcana.WebApi.ApiServices.Users;
using Arcana.WebApi.Helpers;
using Arcana.WebApi.Middlewares;
using Arcana.WebApi.Validators.Accounts;
using Arcana.WebApi.Validators.Assets;
using Arcana.WebApi.Validators.CourseCategories;
using Arcana.WebApi.Validators.CourseComments;
using Arcana.WebApi.Validators.CourseModules;
using Arcana.WebApi.Validators.Courses;
using Arcana.WebApi.Validators.InstructorComments;
using Arcana.WebApi.Validators.Instructors;
using Arcana.WebApi.Validators.InstructorStars;
using Arcana.WebApi.Validators.Languages;
using Arcana.WebApi.Validators.LessonComments;
using Arcana.WebApi.Validators.Lessons;
using Arcana.WebApi.Validators.Permissions;
using Arcana.WebApi.Validators.QuestionOptions;
using Arcana.WebApi.Validators.Questions;
using Arcana.WebApi.Validators.QuizApplications;
using Arcana.WebApi.Validators.QuizQuestions;
using Arcana.WebApi.Validators.RolePermissions;
using Arcana.WebApi.Validators.StudentCourses;
using Arcana.WebApi.Validators.Students;
using Arcana.WebApi.Validators.UserRoles;
using Arcana.WebApi.Validators.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Arcana.WebApi.Extensions;

public static class ServicesCollection
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserRoleService, UserRoleService>();
        services.AddScoped<IInstructorService, InstructorService>();
        services.AddScoped<IStudentService, StudentService>();
        services.AddScoped<IAssetService, AssetService>();
        services.AddScoped<IPermissionService, PermissionService>();
        services.AddScoped<IRolePermissionService, RolePermissionService>();
        services.AddScoped<ICourseService, CourseService>();
        services.AddScoped<ILessonCommentService, LessonCommentService>();
        services.AddScoped<ILessonService, LessonService>();
        services.AddScoped<IQuestionService, QuestionService>();
        services.AddScoped<IQuestionOptionService, QuestionOptionService>();
        services.AddScoped<IQuizApplicationService, QuizApplicationService>();
        services.AddScoped<IQuizQuestionService, QuizQuestionService>();
        services.AddScoped<IStudentCourseService, StudentCourseService>();
        services.AddScoped<ICourseCategoryService, CourseCategoryService>();
        services.AddScoped<ICourseCommentService, CourseCommentService>();
        services.AddScoped<ICourseModuleService, CourseModuleService>();
        services.AddScoped<IInstructorCommentService, InstructorCommentService>();
        services.AddScoped<IInstructorStarsService, InstructorStarService>();
        services.AddScoped<ILanguageService, LanguageService>();
        services.AddScoped<IQuizService, QuizService>();
    }

    public static void AddApiServices(this IServiceCollection services)
    {
        services.AddScoped<IUserApiService, UserApiService>();
        services.AddScoped<IStudentApiService, StudentApiService>();
        services.AddScoped<IInstructorApiService, InstructorApiService>();
        services.AddScoped<IPermissionApiService, PermissionApiService>();
        services.AddScoped<IRolePermissionApiService, RolePermissionApiService>();
        services.AddScoped<IUserRoleApiService, UserRoleApiService>();
        services.AddScoped<IAccountApiService, AccountApiService>();
        services.AddScoped<ICourseApiService, CourseApiService>();
        services.AddScoped<ILessonCommentApiService, LessonCommentApiService>();
        services.AddScoped<ILessonApiService, LessonApiService>();
        services.AddScoped<IQuestionOptionApiService, QuestionOptionApiService>();
        services.AddScoped<IQuestionApiService, QuestionApiService>();
        services.AddScoped<IQuizQuestionApiService, QuizQuestionApiService>();
        services.AddScoped<IQuizApplicationApiService, QuizApplicationApiService>();
        services.AddScoped<IStudentCourseApiService, StudentCourseApiService>();
        services.AddScoped<ICourseCategoryApiService, CourseCategoryApiService>();
        services.AddScoped<ICourseCommentApiService, CourseCommentApiService>();
        services.AddScoped<ICourseModuleApiService, CourseModuleApiService>();
        services.AddScoped<IInstructorCommentApiService, InstructorCommentApiService>();
        services.AddScoped<IInsturctorStarsApiService, InstructorStarsApiService>();
        services.AddScoped<ILanguageApiService, LanguageApiService>();
    }

    public static void AddValidators(this IServiceCollection services)
    {
        services.AddTransient<UserCreateModelValidator>();
        services.AddTransient<UserUpdateModelValidator>();
        services.AddTransient<UserChangePasswordModelValidator>();

        services.AddTransient<UserRoleCreateModelValidator>();
        services.AddTransient<UserRoleUpdateModelValidator>();

        services.AddTransient<InstructorCreateModelValidator>();
        services.AddTransient<InstructorUpdateModelValidator>();

        services.AddTransient<StudentCreateModelValidator>();
        services.AddTransient<StudentUpdateModelValidator>();

        services.AddTransient<PermissionCreateModelValidator>();
        services.AddTransient<PermissionUpdateModelValidator>();

        services.AddTransient<CourseCreateModelValidator>();
        services.AddTransient<CourseUpdateModelValidator>();

        services.AddTransient<LessonCommentCreateModelValidator>();
        services.AddTransient<LessonCommentUpdateModelValidator>();

        services.AddTransient<LessonCreateModelValidator>();
        services.AddTransient<LessonUpdateModelValidator>();

        services.AddTransient<QuestionOptionCreateModelValidator>();
        services.AddTransient<QuestionOptionUpdateModelValidator>();

        services.AddTransient<QuestionCreateModelValidator>();
        services.AddTransient<QuestionUpdateModelValidator>();

        services.AddTransient<StudentCourseCreateModelValidator>();
        services.AddTransient<StudentCourseUpdateModelValidator>();

        services.AddTransient<RolePermissionCreateModelValidator>();

        services.AddTransient<LoginModelValidator>();
        services.AddTransient<ResetPasswordModelValidator>();
        services.AddTransient<SendCodeModelValidator>();
        services.AddTransient<ConfirmCodeModelValidator>();

        services.AddTransient<CourseCategoryCreateModelValidator>();
        services.AddTransient<CourseCategoryUpdateModelValidator>();

        services.AddTransient<CourseCommentCreateModelValidator>();
        services.AddTransient<CourseCommentUpdateModelValidator>();

        services.AddTransient<CourseModuleCreateModelValidator>();
        services.AddTransient<CourseModuleUpdateModelValidator>();

        services.AddTransient<InstructorCommentCreateModelValidator>();
        services.AddTransient<InstructorCommentUpdateModelValidator>();

        services.AddTransient<InstructorStarsCreateModelValidator>();
        services.AddTransient<InstructorStarsUpdateModelValidator>();

        services.AddTransient<LanguageCreateModelValidator>();
        services.AddTransient<LanguageUpdateModelValidator>();

        services.AddTransient<QuizApplicationCreateModelValidator>();
        services.AddTransient<QuizApplicationUpdateModelValidator>();

        services.AddTransient<QuizQuestionCreateModelValidator>();
        services.AddTransient<QuizQuestionUpdateModelValidator>();

        services.AddTransient<AssetCreateModelValidator>();
    }

    public static void AddExceptionHandlers(this IServiceCollection services)
    {
        services.AddExceptionHandler<NotFoundExceptionHandler>();
        services.AddExceptionHandler<AlreadyExistExceptionHandler>();
        services.AddExceptionHandler<ArgumentIsNotValidExceptionHandler>();
        services.AddExceptionHandler<CustomExceptionHandler>();
        services.AddExceptionHandler<InternalServerExceptionHandler>();
    }

    public static void AddInjectHelper(this WebApplication serviceProvider)
    {
        var scope = serviceProvider.Services.CreateScope();
        InjectHelper.RolePermissionService = scope.ServiceProvider.GetRequiredService<IRolePermissionService>();
    }

    public static void InjectEnvironmentItems(this WebApplication app)
    {
        HttpContextHelper.ContextAccessor = app.Services.GetRequiredService<IHttpContextAccessor>();
        EnvironmentHelper.WebRootPath = Path.GetFullPath("wwwroot");
        EnvironmentHelper.JWTKey = app.Configuration.GetSection("JWT:Key").Value;
        EnvironmentHelper.TokenLifeTimeInHours = app.Configuration.GetSection("JWT:LifeTime").Value;
        EnvironmentHelper.EmailAddress = app.Configuration.GetSection("Email:EmailAddress").Value;
        EnvironmentHelper.EmailPassword = app.Configuration.GetSection("Email:Password").Value;
        EnvironmentHelper.SmtpPort = app.Configuration.GetSection("Email:Port").Value;
        EnvironmentHelper.SmtpHost = app.Configuration.GetSection("Email:Host").Value;
        EnvironmentHelper.PageSize = Convert.ToInt32(app.Configuration.GetSection("PaginationParams:PageSize").Value);
        EnvironmentHelper.PageIndex = Convert.ToInt32(app.Configuration.GetSection("PaginationParams:PageIndex").Value);
    }

    public static void AddJwtService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(o =>
        {
            var key = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
            o.SaveToken = true;
            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["JWT:Issuer"],
                ValidAudience = configuration["JWT:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(key)
            };
        });
    }

    public static void ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(setup =>
        {
            var jwtSecurityScheme = new OpenApiSecurityScheme
            {
                BearerFormat = "JWT",
                Name = "JWT Authentication",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = JwtBearerDefaults.AuthenticationScheme,
                Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

                Reference = new OpenApiReference
                {
                    Id = JwtBearerDefaults.AuthenticationScheme,
                    Type = ReferenceType.SecurityScheme
                }
            };

            setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

            setup.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { jwtSecurityScheme, Array.Empty<string>() }
                });
        });
    }
}
