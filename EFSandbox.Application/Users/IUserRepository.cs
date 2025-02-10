using EFSandbox.Domain.UsersAggregate;

namespace EFSandbox.Application.Users;

public interface IUserRepository
{
    Task<User?> FindAsync(int id, CancellationToken cancellationToken);
    Task<List<User>> FindAllAsync(HashSet<int> ids, CancellationToken cancellationToken);
    Task<bool> ExistAsync(int id, CancellationToken cancellationToken);
    Task AddAsync(User entity, CancellationToken cancellationToken);
    void Update(User entity);
    void Remove(User entity);
}