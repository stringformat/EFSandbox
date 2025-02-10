using EFSandbox.Common;
using EFSandbox.Domain.SurveysAggregate.Ready;

namespace EFSandbox.Application.Surveys.UseCases.Edit;

public class EditSurveyUseCase(ISurveyRepository repository, IUnitOfWork unitOfWork)
{
    public async Task<Response> HandleAsync(Request request, CancellationToken cancellationToken)
    {
        if(!await repository.ExistAsync(request.SurveyId, cancellationToken))
            return null;
        
        var survey = await repository.FindAsync<ReadySurvey>(request.SurveyId, CancellationToken.None);
        
        survey.Edit();
        
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new();
    } 
    
    public record Request(int SurveyId);

    public record Response();
}