using EFSandbox.Domain.UsersAggregate;

namespace EFSandbox.Domain.QuestionsAggregate.Answers;

public partial class TextAnswer : Answer
{
    public TextResponse Response { get; }

    // EF
    private TextAnswer()
    {
    }

    private TextAnswer(TextResponse response, User user) : base(user)
    {
        Response = response;
    }

    public static TextAnswer Create(string response, User user)
    {
        ArgumentNullException.ThrowIfNull(response);
        ArgumentNullException.ThrowIfNull(user);
        
        return new(TextResponse.Create(response), user);
    }
}