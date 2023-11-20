using PCT.Domain.PersonalValue;

namespace PCT.Application.Repositories;

public interface IPersonalValueRepository: IBaseRepository<PersonalValue>
{
    void Add(PersonalValue personalValue);
}