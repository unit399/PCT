using PCT.Application.Common.Contracts;
using PCT.Domain.Common.Entity;

namespace PCT.Application.Account.Login;

public sealed record LoginUserResponse : BaseResponse
{
    public string? Token { get; set; }
}