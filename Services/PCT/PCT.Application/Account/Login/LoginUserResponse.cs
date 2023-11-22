using PCT.Domain.Common.Entity;

namespace PCT.Application.Account.Login;

public sealed record LoginUserResponse
{
    public string? Token { get; set; }
    public StatusCode? StatusCode { get; set; }
}