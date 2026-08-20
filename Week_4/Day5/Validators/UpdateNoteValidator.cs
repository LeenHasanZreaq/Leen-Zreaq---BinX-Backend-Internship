using FluentValidation;
using MyWebProject.DTOs;

namespace MyWebProject.Validators;

public class UpdateNoteValidator : AbstractValidator<UpdateNoteRequest>
{
    public UpdateNoteValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Content)
            .NotEmpty()
            .MaximumLength(1000);
    }
}