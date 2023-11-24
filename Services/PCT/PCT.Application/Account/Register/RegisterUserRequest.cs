using MediatR;

namespace PCT.Application.Account.Register;

public sealed record RegisterUserRequest(string Email, string Password) : IRequest<RegisterUserResponse>;