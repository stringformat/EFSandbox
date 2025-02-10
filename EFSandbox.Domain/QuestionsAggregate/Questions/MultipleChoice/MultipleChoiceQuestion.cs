using System.Collections.Immutable;
using EFSandbox.Domain.QuestionsAggregate.Answers;
using EFSandbox.Domain.UsersAggregate;

namespace EFSandbox.Domain.QuestionsAggregate.Questions.MultipleChoice;

public partial class MultipleChoiceQuestion : Question
{
    public override QuestionType Type { get; protected set; } = QuestionType.MultipleChoice;
    
    private readonly List<Option> _options;
    public ImmutableList<Option> Options => _options.ToImmutableList();

    // EF
    private MultipleChoiceQuestion() : base()
    {
    }

    private MultipleChoiceQuestion(QuestionTitle title, QuestionDescription description, List<Option> options) : base(title, description)
    {
        _options = options;
    }

    public static MultipleChoiceQuestion Create(QuestionTitle title, QuestionDescription description, List<Option> options)
    {
        ArgumentNullException.ThrowIfNull(title);
        ArgumentNullException.ThrowIfNull(description);
        
        return new(title, description, options);
    }
    
    public void Answer(int optionId, User user)
    {
        base.Answer(MultipleChoiceAnswer.Create(optionId, user));
    }

    public void AddOption(Option option)
    {
        ArgumentNullException.ThrowIfNull(option);

        if (_options.Count > 10)
            return;
        
        _options.Add(option);
    }
}