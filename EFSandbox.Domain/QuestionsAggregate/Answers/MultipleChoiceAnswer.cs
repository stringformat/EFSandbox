using EFSandbox.Domain.UsersAggregate;

namespace EFSandbox.Domain.QuestionsAggregate.Answers;

public class MultipleChoiceAnswer : Answer
{
    public int OptionId { get; }

    // EF
    private MultipleChoiceAnswer()
    {
    }

    private MultipleChoiceAnswer(int optionId, User user) : base(user)
    {
        OptionId = optionId;
    }

    public static MultipleChoiceAnswer Create(int optionId, User user)
    {
        ArgumentNullException.ThrowIfNull(user);
        
        return new(optionId, user);
    }
}