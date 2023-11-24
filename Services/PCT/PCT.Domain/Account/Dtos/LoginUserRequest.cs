using FluentValidation;
using MediatR;

namespace PCT.Domain.Account.Dtos;

public sealed record LoginUserRequest(string Email, string Password) : IRequest<LoginUserResponse>;

public sealed class LoginUserValidator : AbstractValidator<LoginUserRequest>
{
    public LoginUserValidator()
    {
        RuleFor(x => x.Email).NotEmpty().MaximumLength(50).EmailAddress();
        RuleFor(x => x.Password).NotEmpty().MinimumLength(8).MaximumLength(50);
    }
}