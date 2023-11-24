using MediatR;

namespace PCT.Application.Account.Login;

public sealed record LoginUserRequest(string Email, string Password) : IRequest<LoginUserResponse>;