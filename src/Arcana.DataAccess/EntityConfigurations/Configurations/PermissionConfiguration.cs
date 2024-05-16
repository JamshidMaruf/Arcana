using Arcana.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Arcana.DataAccess.EntityConfigurations.Commons;

namespace Arcana.DataAccess.EntityConfigurations.Configurations;

public class PermissionConfiguration : IEntityConfiguration
{
    public void Configure(ModelBuilder modelBuilder)
     {  }

    public void SeedData(ModelBuilder modelBuilder)
    {
        // Permission
        modelBuilder.Entity<Permission>().HasData(
                new Permission { Id = 1, Action = "PostAsync", Controller = "Students", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 2, Action = "PutAsync", Controller = "Students", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 3, Action = "DeleteAsync", Controller = "Students", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 4, Action = "GetAllAsync", Controller = "Students", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 5, Action = "GetAsync", Controller = "Students", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 6, Action = "UploadPictureAsync", Controller = "Students", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 7, Action = "DeletePictureAsync", Controller = "Students", CreatedAt = DateTime.UtcNow },

                new Permission { Id = 8, Action = "PostAsync", Controller = "Instructors", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 9, Action = "PutAsync", Controller = "Instructors", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 10, Action = "DeleteAsync", Controller = "Instructors", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 11, Action = "GetAllAsync", Controller = "Instructors", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 12, Action = "GetAsync", Controller = "Instructors", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 13, Action = "UploadPictureAsync", Controller = "Instructors", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 14, Action = "DeletePictureAsync", Controller = "Instructors", CreatedAt = DateTime.UtcNow },

                new Permission { Id = 15, Action = "PostAsync", Controller = "Users", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 16, Action = "PutAsync", Controller = "Users", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 17, Action = "DeleteAsync", Controller = "Users", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 18, Action = "GetAllAsync", Controller = "Users", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 19, Action = "GetAsync", Controller = "Users", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 20, Action = "ChangePasswordAsync", Controller = "Users", CreatedAt = DateTime.UtcNow },

                new Permission { Id = 21, Action = "PostAsync", Controller = "Lessons", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 22, Action = "PutAsync", Controller = "Lessons", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 23, Action = "DeleteAsync", Controller = "Lessons", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 24, Action = "GetAllAsync", Controller = "Lessons", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 25, Action = "GetAsync", Controller = "Lessons", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 26, Action = "UploadPictureAsync", Controller = "Lessons", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 27, Action = "DeletePictureAsync", Controller = "Lessons", CreatedAt = DateTime.UtcNow },

                new Permission { Id = 28, Action = "PostAsync", Controller = "Courses", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 29, Action = "PutAsync", Controller = "Courses", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 30, Action = "DeleteAsync", Controller = "Courses", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 31, Action = "GetAllAsync", Controller = "Courses", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 32, Action = "GetAsync", Controller = "Courses", CreatedAt = DateTime.UtcNow },

                new Permission { Id = 33, Action = "PostAsync", Controller = "UserRoles", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 34, Action = "PutAsync", Controller = "UserRoles", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 35, Action = "DeleteAsync", Controller = "UserRoles", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 36, Action = "GetAllAsync", Controller = "UserRoles", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 37, Action = "GetAsync", Controller = "UserRoles", CreatedAt = DateTime.UtcNow },

                new Permission { Id = 38, Action = "PostAsync", Controller = "Permissions", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 39, Action = "PutAsync", Controller = "Permissions", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 40, Action = "DeleteAsync", Controller = "Permissions", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 41, Action = "GetAllAsync", Controller = "Permissions", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 42, Action = "GetAsync", Controller = "Permissions", CreatedAt = DateTime.UtcNow },

                new Permission { Id = 43, Action = "PostAsync", Controller = "StudentCourses", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 44, Action = "PutAsync", Controller = "StudentCourses", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 45, Action = "DeleteAsync", Controller = "StudentCourses", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 46, Action = "GetAllAsync", Controller = "StudentCourses", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 47, Action = "GetAsync", Controller = "StudentCourses", CreatedAt = DateTime.UtcNow },

                new Permission { Id = 48, Action = "PostAsync", Controller = "Quizzes", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 49, Action = "PutAsync", Controller = "Quizzes", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 50, Action = "DeleteAsync", Controller = "Quizzes", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 51, Action = "GetAllAsync", Controller = "Quizzes", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 52, Action = "GetAsync", Controller = "Quizzes", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 53, Action = "GenerateQuestionsAsync", Controller = "Quizzes", CreatedAt = DateTime.UtcNow },

                new Permission { Id = 54, Action = "PostAsync", Controller = "QuizQuestions", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 55, Action = "PutAsync", Controller = "QuizQuestions", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 56, Action = "DeleteAsync", Controller = "QuizQuestions", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 57, Action = "GetAllAsync", Controller = "QuizQuestions", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 58, Action = "GetAsync", Controller = "QuizQuestions", CreatedAt = DateTime.UtcNow },

                new Permission { Id = 59, Action = "PostAsync", Controller = "QuizApplications", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 60, Action = "PutAsync", Controller = "QuizApplications", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 61, Action = "DeleteAsync", Controller = "QuizApplications", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 62, Action = "GetAllAsync", Controller = "QuizApplications", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 63, Action = "GetAsync", Controller = "QuizApplications", CreatedAt = DateTime.UtcNow },

                new Permission { Id = 64, Action = "PostAsync", Controller = "Questions", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 65, Action = "PutAsync", Controller = "Questions", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 66, Action = "DeleteAsync", Controller = "Questions", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 67, Action = "GetAllAsync", Controller = "Questions", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 68, Action = "GetAsync", Controller = "Questions", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 69, Action = "UploadPictureAsync", Controller = "Questions", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 70, Action = "DeletePictureAsync", Controller = "Questions", CreatedAt = DateTime.UtcNow },

                new Permission { Id = 71, Action = "PostAsync", Controller = "UserRoles", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 72, Action = "PutAsync", Controller = "UserRoles", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 73, Action = "DeleteAsync", Controller = "UserRoles", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 74, Action = "GetAllAsync", Controller = "UserRoles", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 75, Action = "GetAsync", Controller = "UserRoles", CreatedAt = DateTime.UtcNow },

                new Permission { Id = 76, Action = "PostAsync", Controller = "QuestionOptions", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 77, Action = "PutAsync", Controller = "QuestionOptions", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 78, Action = "DeleteAsync", Controller = "QuestionOptions", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 79, Action = "GetAllAsync", Controller = "QuestionOptions", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 80, Action = "GetAsync", Controller = "QuestionOptions", CreatedAt = DateTime.UtcNow },

                new Permission { Id = 81, Action = "PostAsync", Controller = "QuestionAnswers", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 82, Action = "PutAsync", Controller = "QuestionAnswers", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 83, Action = "DeleteAsync", Controller = "QuestionAnswers", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 84, Action = "GetAllAsync", Controller = "QuestionAnswers", CreatedAt = DateTime.UtcNow },

                new Permission { Id = 86, Action = "PostAsync", Controller = "LessonComments", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 87, Action = "PutAsync", Controller = "LessonComments", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 88, Action = "DeleteAsync", Controller = "LessonComments", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 89, Action = "GetAllAsync", Controller = "LessonComments", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 90, Action = "GetAsync", Controller = "LessonComments", CreatedAt = DateTime.UtcNow },

                new Permission { Id = 91, Action = "PostAsync", Controller = "Languages", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 92, Action = "PutAsync", Controller = "Languages", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 93, Action = "DeleteAsync", Controller = "Languages", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 94, Action = "GetAllAsync", Controller = "Languages", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 95, Action = "GetAsync", Controller = "Languages", CreatedAt = DateTime.UtcNow },

                new Permission { Id = 96, Action = "PostAsync", Controller = "InstructorStars", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 97, Action = "PutAsync", Controller = "InstructorStars", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 98, Action = "DeleteAsync", Controller = "InstructorStars", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 99, Action = "GetAllAsync", Controller = "InstructorStars", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 100, Action = "GetAsync", Controller = "InstructorStars", CreatedAt = DateTime.UtcNow },

                new Permission { Id = 101, Action = "PostAsync", Controller = "InstructorComments", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 102, Action = "PutAsync", Controller = "InstructorComments", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 103, Action = "DeleteAsync", Controller = "InstructorComments", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 104, Action = "GetAllAsync", Controller = "InstructorComments", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 105, Action = "GetAsync", Controller = "InstructorComments", CreatedAt = DateTime.UtcNow },

                new Permission { Id = 106, Action = "PostAsync", Controller = "RolePermissions", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 107, Action = "PutAsync", Controller = "RolePermissions", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 108, Action = "DeleteAsync", Controller = "RolePermissions", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 109, Action = "GetAllAsync", Controller = "RolePermissions", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 110, Action = "GetAsync", Controller = "RolePermissions", CreatedAt = DateTime.UtcNow },

                new Permission { Id = 111, Action = "PostAsync", Controller = "CourseModules", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 112, Action = "PutAsync", Controller = "CourseModules", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 113, Action = "DeleteAsync", Controller = "CourseModules", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 114, Action = "GetAllAsync", Controller = "CourseModules", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 115, Action = "GetAsync", Controller = "CourseModules", CreatedAt = DateTime.UtcNow },

                new Permission { Id = 116, Action = "PostAsync", Controller = "CourseStar", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 117, Action = "PutAsync", Controller = "CourseStar", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 118, Action = "DeleteAsync", Controller = "CourseStar", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 119, Action = "GetAllAsync", Controller = "CourseStar", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 120, Action = "GetAsync", Controller = "CourseStar", CreatedAt = DateTime.UtcNow },

                new Permission { Id = 121, Action = "PostAsync", Controller = "CourseComments", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 122, Action = "PutAsync", Controller = "CourseComments", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 123, Action = "DeleteAsync", Controller = "CourseComments", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 124, Action = "GetAllAsync", Controller = "CourseComments", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 125, Action = "GetAsync", Controller = "CourseComments", CreatedAt = DateTime.UtcNow },

                new Permission { Id = 126, Action = "PostAsync", Controller = "CourseCategories", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 127, Action = "PutAsync", Controller = "CourseCategories", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 128, Action = "DeleteAsync", Controller = "CourseCategories", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 129, Action = "GetAllAsync", Controller = "CourseCategories", CreatedAt = DateTime.UtcNow },
                new Permission { Id = 130, Action = "GetAsync", Controller = "CourseCategories", CreatedAt = DateTime.UtcNow }
            );
    }
}