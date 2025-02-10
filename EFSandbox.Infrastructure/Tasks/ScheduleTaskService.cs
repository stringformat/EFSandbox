using EFSandbox.Domain.SurveysAggregate.Services;

namespace EFSandbox.Infrastructure.Tasks;

public class ScheduleTaskService(IScheduleTaskRepository repository) : IScheduleTaskService
{
    public async Task CreateTask(string name, CancellationToken cancellationToken)
    {
        var task = new ScheduleTask(name);
        
        await repository.AddAsync(task, cancellationToken);
    }
}