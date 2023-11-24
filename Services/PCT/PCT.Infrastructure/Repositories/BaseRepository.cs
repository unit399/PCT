using Microsoft.EntityFrameworkCore;
using PCT.Application.Repositories;
using PCT.Domain.Common.Entities;
using PCT.Infrastructure.Context;

namespace PCT.Infrastructure.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    protected readonly ApplicationDbContext Context;

    protected BaseRepository(ApplicationDbContext context)
    {
        Context = context;
    }

    public void Create(T entity)
    {
        Context.Add(entity);
    }

    public void Update(T entity)
    {
        Context.Update(entity);
    }

    public void Delete(T entity)
    {
        entity.DateCreated = DateTimeOffset.UtcNow;
        Context.Update(entity);
    }

    public Task<T?> Get(Guid id, CancellationToken cancellationToken)
    {
        return Context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public Task<List<T>> GetAll(CancellationToken cancellationToken)
    {
        return Context.Set<T>().ToListAsync(cancellationToken);
    }
}