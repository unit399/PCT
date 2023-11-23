using FluentValidation;

namespace PCT.Application.PersonalValue.Add;

public class AddPersonalValueValidator : AbstractValidator<AddPersonalValueRequest>
{
    public AddPersonalValueValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
    }
}