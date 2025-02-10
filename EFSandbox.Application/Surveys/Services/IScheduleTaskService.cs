namespace EFSandbox.Domain.SurveysAggregate.Services;

public interface IScheduleTaskService
{
    Task CreateTask(string name, CancellationToken cancellationToken);
}