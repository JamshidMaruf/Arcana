using Arcana.WebApi.Models.QuizQuestions;
using FluentValidation;

namespace Arcana.WebApi.Validators.QuizQuestions;


public class QuizQuestionCreateModelValidator : AbstractValidator<QuizQuestionCreateModel>
{
    public QuizQuestionCreateModelValidator()
    {
        RuleFor(quizQuestion => quizQuestion.QuestionId)
            .NotNull()
            .WithMessage(quizQuestion => $"{nameof(quizQuestion.QuestionId)} is not specified");

        RuleFor(quizQuestion => quizQuestion.QuizId)
            .NotNull()
            .WithMessage(quizQuestion => $"{nameof(quizQuestion.QuizId)} is not specified");
    }
}