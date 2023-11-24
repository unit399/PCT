using Microsoft.EntityFrameworkCore;
using PCT.Domain.Account.Entities;
using PCT.Domain.Account.RepositoryContracts;
using PCT.Infrastructure.Context;

namespace PCT.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task<User?> GetByEmail(string email, CancellationToken cancellationToken)
    {
        return _context.Users.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
    }

    public Task<List<User>> GetAll(CancellationToken cancellationToken)
    {
        return _context.Users.ToListAsync(cancellationToken);
    }
}