using PCT.Domain.Common.Entity;

namespace PCT.Application.Account.Register;

public sealed record RegisterUserResponse
{
    public Guid Id { get; set; }
    public string? Email { get; set; }
    public StatusCode? StatusCode { get; set; }
}