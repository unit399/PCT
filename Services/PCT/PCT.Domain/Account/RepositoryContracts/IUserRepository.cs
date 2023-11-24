using PCT.Domain.Account.Entities;

namespace PCT.Domain.Account.RepositoryContracts;

public interface IUserRepository
{
    Task<User?> GetByEmail(string email, CancellationToken cancellationToken);
    Task<List<User>> GetAll(CancellationToken cancellationToken);
}