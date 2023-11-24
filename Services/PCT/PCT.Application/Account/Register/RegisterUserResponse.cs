using PCT.Application.Common.Contracts;

namespace PCT.Application.Account.Register;

public sealed record RegisterUserResponse : BaseResponse
{
    public Guid Id { get; set; }
    public string? Email { get; set; }
}