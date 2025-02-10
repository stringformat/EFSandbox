using EFSandbox.Common;
using EFSandbox.Domain.SurveysAggregate.Draft;
using EFSandbox.Domain.SurveysAggregate.Services;

namespace EFSandbox.Application.Surveys.UseCases.Schedule;

public class ScheduleSurveyUseCase(ISurveyRepository repository, IUnitOfWork unitOfWork, IScheduleTaskService scheduleTaskService)
{
    public async Task HandleAsync()
    {
        var survey = await repository.FindAsync<DraftSurvey>(1, CancellationToken.None);
        
        if (survey is null)
            return;
        
        survey.ScheduleLater(DateTimeOffset.UtcNow, DateTimeOffset.UtcNow.AddDays(3));
        
        await scheduleTaskService.CreateTask("ma tâche", CancellationToken.None);
        
        await unitOfWork.SaveChangesAsync(CancellationToken.None);
    } 
}