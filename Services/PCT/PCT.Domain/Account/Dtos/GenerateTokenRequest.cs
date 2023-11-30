using MediatR;

namespace PCT.Domain.Account.Dtos;

public sealed record GenerateTokenRequest(string Email) : IRequest<GenerateTokenResponse>;