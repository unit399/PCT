using PCT.Application.Common.Contracts;

namespace PCT.Application.Account.Login;

public sealed record LoginUserResponse : BaseResponse
{
    public string? Token { get; set; }
}