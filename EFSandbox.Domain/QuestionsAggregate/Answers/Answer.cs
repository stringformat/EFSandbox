using EFSandbox.Common;
using EFSandbox.Domain.UsersAggregate;

namespace EFSandbox.Domain.QuestionsAggregate.Answers;

public abstract class Answer : Entity
{
    public User User { get; }
    
    // EF
    protected Answer()
    {
    }

    protected Answer(User user)
    {
        User = user;
    }
}