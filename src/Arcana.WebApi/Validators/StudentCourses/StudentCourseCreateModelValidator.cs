using Arcana.WebApi.Models.StudentCourses;
using FluentValidation;

namespace Arcana.WebApi.Validators.StudentCourses;

public class StudentCourseCreateModelValidator : AbstractValidator<StudentCourseCreateModel>
{
    public StudentCourseCreateModelValidator()
    {
        RuleFor(studentCourse => studentCourse.StudentId)
        .NotNull()
        .WithMessage(studentCourse => $"{nameof(studentCourse.StudentId)} is not specified");

        RuleFor(studentCourse => studentCourse.CourseId)
       .NotNull()
       .WithMessage(studentCourse => $"{nameof(studentCourse.CourseId)} is not specified");

        RuleFor(studentCourse => studentCourse.InstructorId)
       .NotNull()
       .WithMessage(studentCourse => $"{nameof(studentCourse.InstructorId)} is not specified");
    }
}
