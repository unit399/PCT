namespace PCT.Domain.Common.RepositoryContracts;

public interface IUnitOfWork
{
    Task Save(CancellationToken cancellationToken);
}