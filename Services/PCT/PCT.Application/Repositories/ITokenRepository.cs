using PCT.Application.Account.Token;

namespace PCT.Application.Repositories;

public interface ITokenRepository
{
    public Task<GenerateTokenResponse> GenerateToken(GenerateTokenRequest request);
}