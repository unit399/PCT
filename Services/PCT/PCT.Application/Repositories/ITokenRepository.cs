using PCT.Domain.Account.Dtos;

namespace PCT.Application.Repositories;

public interface ITokenRepository
{
    public Task<GenerateTokenResponse> GenerateToken(GenerateTokenRequest request);
}