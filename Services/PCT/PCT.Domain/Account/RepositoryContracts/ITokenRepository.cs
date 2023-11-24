using PCT.Domain.Account.Dtos;

namespace PCT.Domain.Account.RepositoryContracts;

public interface ITokenRepository
{
    public Task<GenerateTokenResponse> GenerateToken(GenerateTokenRequest request);
}