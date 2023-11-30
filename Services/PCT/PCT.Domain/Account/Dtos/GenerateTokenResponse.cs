namespace PCT.Domain.Account.Dtos;

public sealed record GenerateTokenResponse
{
    public string Token { get; set; } = string.Empty;
    public DateTime TokenExpireDate { get; set; }
}