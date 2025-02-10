using EFSandbox.Domain.QuestionsAggregate.Answers;
using EFSandbox.Domain.UsersAggregate;

namespace EFSandbox.Domain.QuestionsAggregate.Questions;

public class TextQuestion : Question
{
    public override QuestionType Type { get; protected set; } = QuestionType.Text;

    // EF
    private TextQuestion() : base()
    {
    }

    private TextQuestion(QuestionTitle title, QuestionDescription description) : base(title, description)
    {
    }

    public static TextQuestion Create(QuestionTitle title, QuestionDescription description)
    {
        ArgumentNullException.ThrowIfNull(title);
        ArgumentNullException.ThrowIfNull(description);
        
        return new(title, description);
    }

    public void Answer(string response, User user)
    {
        base.Answer(TextAnswer.Create(response, user));
    }
}