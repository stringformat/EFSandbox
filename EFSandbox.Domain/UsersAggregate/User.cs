using EFSandbox.Common;

namespace EFSandbox.Domain.UsersAggregate;

public partial class User : Entity, IAggregateRoot
{
    // EF
    private User()
    {
    }

    public UserName Name { get; }
}