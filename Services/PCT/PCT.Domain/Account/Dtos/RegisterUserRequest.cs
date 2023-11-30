using FluentValidation;
using MediatR;

namespace PCT.Domain.Account.Dtos;

public sealed record RegisterUserRequest(string Email, string Password) : IRequest<RegisterUserResponse>;

public sealed class RegisterUserValidator : AbstractValidator<RegisterUserRequest>
{
    public RegisterUserValidator()
    {
        RuleFor(x => x.Email).NotEmpty().MaximumLength(50).EmailAddress();
        RuleFor(x => x.Password).NotEmpty().MinimumLength(8).MaximumLength(50);
    }
}