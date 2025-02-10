using EFSandbox.Application.Surveys;
using EFSandbox.Domain.SurveysAggregate;
using EFSandbox.Infrastructure.Common;

namespace EFSandbox.Infrastructure.Surveys;

public class SurveyRepository(Context context) : RepositoryBase<Survey>(context), ISurveyRepository
{
    public async Task<TSurvey?> FindAsync<TSurvey>(int id, CancellationToken cancellationToken)
        where TSurvey : Survey
    {
        return await base.FindAsync(id, cancellationToken) as TSurvey;
    }
}