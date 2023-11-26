using PCT.Domain.Account.Entities;
using PCT.Domain.Common.Entities;

namespace PCT.Domain.Session.Entities;

public class Session : BaseEntity
{
    public DateTimeOffset Date { get; set; }
    public string? Notes { get; set; }
    public Guid ClientId { get; set; }
    public Client Client { get; set; } = null!;
    public Guid CoachId { get; set; }
    public Coach Coach { get; set; } = null!;
}