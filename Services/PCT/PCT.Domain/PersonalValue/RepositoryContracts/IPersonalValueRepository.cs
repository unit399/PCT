using PCT.Domain.Common.RepositoryContracts;

namespace PCT.Domain.PersonalValue.RepositoryContracts;

public interface IPersonalValueRepository : IBaseRepository<Entities.PersonalValue>
{
    void Add(Entities.PersonalValue personalValue);
    Task<bool> Exist(string name);
}