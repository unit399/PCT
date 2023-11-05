namespace PCT.Domain.PersonalValue.Entity;

public class PersonalValue
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Description { get; set; }

    public PersonalValue(string name, string description)
    {
        Name = name;
        Description = description;
    }
}