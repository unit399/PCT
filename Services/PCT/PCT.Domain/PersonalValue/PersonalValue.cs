using PCT.Domain.Common.Entity;

namespace PCT.Domain.PersonalValue;

public class PersonalValue : BaseEntity
{
    public PersonalValue(string name, string description)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Description = description ?? throw new ArgumentNullException(nameof(description));
    }

    public string Name { get; set; }
    public string Description { get; set; }
}