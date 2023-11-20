using PCT.Application.Repositories;
using PCT.Infrastructure.Context;

namespace PCT.Infrastructure.Repositories;

public class PersonalValueRepository : BaseRepository<Domain.PersonalValue.PersonalValue>, IPersonalValueRepository
{
    public PersonalValueRepository(ApplicationDbContext context) : base(context)
    {
    }

    public void Add(Domain.PersonalValue.PersonalValue personalValue)
    {
        throw new NotImplementedException();
    }
}