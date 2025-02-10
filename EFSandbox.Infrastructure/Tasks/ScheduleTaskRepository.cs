using EFSandbox.Infrastructure.Common;

namespace EFSandbox.Infrastructure.Tasks;

public interface IScheduleTaskRepository
{
    Task<ScheduleTask?> FindAsync(int id, CancellationToken cancellationToken);
    Task<List<ScheduleTask>> FindAllAsync(HashSet<int> ids, CancellationToken cancellationToken);
    Task<bool> ExistAsync(int id, CancellationToken cancellationToken);
    Task AddAsync(ScheduleTask entity, CancellationToken cancellationToken);
    void Update(ScheduleTask entity);
    void Remove(ScheduleTask entity);
}

public class ScheduleTaskRepository(Context context) : RepositoryBase<ScheduleTask>(context), IScheduleTaskRepository;