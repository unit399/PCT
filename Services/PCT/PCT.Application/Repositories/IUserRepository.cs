using PCT.Domain.Account;

namespace PCT.Application.Repositories;

public interface IUserRepository
{
    Task<User?> GetByEmail(string email, CancellationToken cancellationToken);
    Task<List<User>> GetAll(CancellationToken cancellationToken);
}