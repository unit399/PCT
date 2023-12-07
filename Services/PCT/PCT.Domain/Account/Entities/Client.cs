using PCT.Domain.Common.Entities;
using PCT.Domain.Common.Enums;

namespace PCT.Domain.Account.Entities;

public sealed class Client : BaseEntity
{
    public User? User { get; set; }
    public Guid UserId { get; set; }
    public string Cellular { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public Gender Gender { get; set; }
    public DateTimeOffset? DateOfBirth { get; set; }
    public string? City { get; set; }
    public List<Session.Entities.Session> Sessions { get; set; } = new();
}