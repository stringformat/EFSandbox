using EFSandbox.Common;
using EFSandbox.Domain.SurveysAggregate.Draft;

namespace EFSandbox.Application.Surveys.UseCases.Validate;

public class ValidateSurveyUseCase(ISurveyRepository repository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync()
    {
        var survey = await repository.FindAsync<DraftSurvey>(1, CancellationToken.None);
        
        if (survey is null)
            return;
        
        survey.Validate();
        
        await unitOfWork.SaveChangesAsync(CancellationToken.None);
    }  
}