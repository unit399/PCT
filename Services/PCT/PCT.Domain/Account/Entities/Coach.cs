using PCT.Domain.Common.Entities;

namespace PCT.Domain.Account.Entities;

public sealed class Coach : BaseEntity
{
    public required User User { get; set; }
    public Guid UserId { get; set; }
    public List<Client> Clients { get; set; } = new();
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Cellular { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? City { get; set; }
}