using EFSandbox.Common;

namespace EFSandbox.Infrastructure.Common;

public class UnitOfWork(Context context) : IUnitOfWork
{
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return await context.SaveChangesAsync(cancellationToken);
    }
}