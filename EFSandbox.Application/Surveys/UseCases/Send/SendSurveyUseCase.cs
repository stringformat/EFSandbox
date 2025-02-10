using EFSandbox.Common;
using EFSandbox.Domain.SurveysAggregate.Ready;

namespace EFSandbox.Application.Surveys.UseCases.Send;

public class SendSurveyUseCase(ISurveyRepository repository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync()
    {
        var survey = await repository.FindAsync<ReadySurvey>(1, CancellationToken.None);
        
        if (survey is null)
            return;
        
        survey.Send();
        
        await unitOfWork.SaveChangesAsync(CancellationToken.None);
    } 
}