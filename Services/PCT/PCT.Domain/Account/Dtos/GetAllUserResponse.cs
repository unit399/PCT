using PCT.Domain.Common.Entities;

namespace PCT.Domain.Account.Dtos;

public sealed record GetAllUserResponse : BaseResponse
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
}