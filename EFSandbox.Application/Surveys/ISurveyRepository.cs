using EFSandbox.Domain.SurveysAggregate;

namespace EFSandbox.Application.Surveys;

public interface ISurveyRepository
{
    Task<Survey?> FindAsync(int id, CancellationToken cancellationToken);
    Task<List<Survey>> FindAllAsync(HashSet<int> ids, CancellationToken cancellationToken);
    Task<bool> ExistAsync(int id, CancellationToken cancellationToken);
    Task AddAsync(Survey entity, CancellationToken cancellationToken);
    void Update(Survey entity);
    void Remove(Survey entity);
    Task<TSurvey?> FindAsync<TSurvey>(int id, CancellationToken cancellationToken) where TSurvey : Survey;
}