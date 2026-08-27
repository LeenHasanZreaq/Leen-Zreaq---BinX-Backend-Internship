using FluentValidation;

public class CreateOrderRequestValidator : AbstractValidator<CreateOrderRequest>
{
    public CreateOrderRequestValidator()
    {
        RuleFor(x => x.CustomerId)
            .GreaterThan(0).WithMessage("CustomerId is required");

        RuleFor(x => x.TableId)
            .GreaterThan(0).WithMessage("TableId must be valid");
    }
}
