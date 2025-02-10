using EFSandbox.Domain.QuestionsAggregate.Questions;

namespace EFSandbox.Application.Questions;

public interface IQuestionRepository
{
    Task<Question?> FindAsync(int id, CancellationToken cancellationToken);
    Task<List<Question>> FindAllAsync(HashSet<int> ids, CancellationToken cancellationToken);
    Task<bool> ExistAsync(int id, CancellationToken cancellationToken);
    Task AddAsync(Question entity, CancellationToken cancellationToken);
    void Update(Question entity);
    void Remove(Question entity);
}