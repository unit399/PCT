using PCT.Domain.Account;

namespace PCT.Application.Repositories;

public interface IUserRepository: IBaseRepository<User>
{
    Task<User?> GetByEmail(string email, CancellationToken cancellationToken);
}