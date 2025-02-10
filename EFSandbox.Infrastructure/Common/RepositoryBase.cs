using EFSandbox.Common;
using Microsoft.EntityFrameworkCore;

namespace EFSandbox.Infrastructure.Common;

public abstract class RepositoryBase<TEntity>(Context dbContext) 
    where TEntity : Entity, IAggregateRoot
{
    public async Task<TEntity?> FindAsync(int id, CancellationToken cancellationToken)
    {
        return await dbContext.Set<TEntity>().FindAsync([id], cancellationToken: cancellationToken);
    }
    
    public async Task<List<TEntity>> FindAllAsync(HashSet<int> ids, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(ids);
        
        if (ids.Count == 0)
            return [];
        
        return await dbContext.Set<TEntity>()
            .Where(e => ids.Contains(e.Id)) // Vérification dans un HashSet
            .ToListAsync(cancellationToken);
    }
    
    public async Task<bool> ExistAsync(int id, CancellationToken cancellationToken)
    {
        return await dbContext.Set<TEntity>().AnyAsync(x => x.Id == id, cancellationToken: cancellationToken);
    }
    
    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        await dbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
    }

    public void Update(TEntity entity)
    {
        dbContext.Set<TEntity>().Update(entity);
    }

    public void Remove(TEntity entity)
    {
        dbContext.Set<TEntity>().Remove(entity);
    }
}