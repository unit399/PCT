using Microsoft.EntityFrameworkCore;
using PCT.Application.Repositories;
using PCT.Domain.Account;
using PCT.Infrastructure.Context;

namespace PCT.Infrastructure.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext context) : base(context)
    {
    }
    
    public Task<User?> GetByEmail(string email, CancellationToken cancellationToken)
    {
        return Context.Users.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
    }
}