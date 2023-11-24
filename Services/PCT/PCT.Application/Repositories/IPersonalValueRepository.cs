namespace PCT.Application.Repositories;

public interface IPersonalValueRepository : IBaseRepository<Domain.PersonalValue.Entities.PersonalValue>
{
    void Add(Domain.PersonalValue.Entities.PersonalValue personalValue);
    Task<bool> Exist(string name);
}