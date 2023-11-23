using PCT.Domain.PersonalValue;

namespace PCT.Application.Repositories;

public interface IPersonalValueRepository: IBaseRepository<Domain.PersonalValue.PersonalValue>
{
    void Add(Domain.PersonalValue.PersonalValue personalValue);
    Task<bool> Exist(string name);
}