using FluentValidation;
using MediatR;

namespace PCT.Domain.PersonalValue.Dtos;

public sealed record AddPersonalValueRequest(string Name, string Description) : IRequest<AddPersonalValueResponse>;

public class AddPersonalValueValidator : AbstractValidator<AddPersonalValueRequest>
{
    public AddPersonalValueValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
    }
}