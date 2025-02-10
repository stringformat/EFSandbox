using EFSandbox.Application.Users;
using EFSandbox.Domain.UsersAggregate;
using EFSandbox.Infrastructure.Common;

namespace EFSandbox.Infrastructure.Users;

public class UserRepository(Context context) : RepositoryBase<User>(context), IUserRepository;