using MediatR;

namespace PCT.Application.Account.Token;

public sealed record GenerateTokenRequest(string Email) : IRequest<GenerateTokenResponse>;