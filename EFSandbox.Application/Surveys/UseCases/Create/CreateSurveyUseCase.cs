using EFSandbox.Common;
using EFSandbox.Domain.SurveysAggregate.Draft;

namespace EFSandbox.Application.Surveys.UseCases.Create;

public class CreateSurveyUseCase(ISurveyRepository repository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(Request request, CancellationToken cancellationToken)
    {
        var survey = DraftSurvey.Create("Mon enquête");

        await repository.AddAsync(survey, cancellationToken);
        
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
    
    public record Request(int SurveyId);

    public record Response();
}