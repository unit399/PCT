using PCT.Application.Common.Contracts;

namespace PCT.Application.Account.GetAll;

public sealed record GetAllUserResponse : BaseResponse
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
}