using EFSandbox.Common;
using EFSandbox.Domain.SurveysAggregate.Sent;

namespace EFSandbox.Application.Surveys.UseCases.Close;

public class CloseSurveyUseCase(ISurveyRepository repository, IUnitOfWork unitOfWork)
{
    public async Task<Response> HandleAsync(Request request, CancellationToken cancellationToken)
    {
        if(!await repository.ExistAsync(request.SurveyId, cancellationToken))
            return null;
        
        var survey = await repository.FindAsync<SentSurvey>(request.SurveyId, cancellationToken);
        
        survey.Close();
        
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new();
    }
    
    public record Request(int SurveyId);

    public record Response();
}