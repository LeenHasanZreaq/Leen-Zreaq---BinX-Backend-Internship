using FluentValidation;
using MyWebProject.DTOs;

namespace MyWebProject.Validators;

public class RegisterValidator : AbstractValidator<RegisterRequest>
{
    public RegisterValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(30);

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(8);
    }
}