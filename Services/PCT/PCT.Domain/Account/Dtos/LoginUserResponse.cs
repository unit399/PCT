using PCT.Domain.Common.Entities;

namespace PCT.Domain.Account.Dtos;

public sealed record LoginUserResponse : BaseResponse
{
    public string? Token { get; set; }
}