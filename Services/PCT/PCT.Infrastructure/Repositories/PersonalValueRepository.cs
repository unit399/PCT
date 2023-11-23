using PCT.Application.Repositories;
using PCT.Domain.PersonalValue;
using PCT.Infrastructure.Context;

namespace PCT.Infrastructure.Repositories;

public class PersonalValueRepository : BaseRepository<Domain.PersonalValue.PersonalValue>, IPersonalValueRepository
{
    private readonly ApplicationDbContext _context;

    public PersonalValueRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public void Add(Domain.PersonalValue.PersonalValue personalValue)
    {
        _context.PersonalValues.Add(personalValue);
    }
    
    public Task<bool> Exist(string name)
    {
        return Task.FromResult(_context.PersonalValues.Any(x => x.Name == name));
    }
}