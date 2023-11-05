namespace PCT.Domain.PersonalValue.Persistence;

public interface IPersonalValueRepository
{
    void Add(Entity.PersonalValue personalValue);
}