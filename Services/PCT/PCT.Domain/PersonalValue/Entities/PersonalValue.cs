using PCT.Domain.Common.Entities;

namespace PCT.Domain.PersonalValue.Entities;

public sealed class PersonalValue : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}