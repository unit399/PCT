using PCT.Domain.Common.Entities;

namespace PCT.Domain.Account.Dtos;

public sealed record RegisterUserResponse : BaseResponse
{
    public Guid Id { get; set; }
    public string? Email { get; set; }
}