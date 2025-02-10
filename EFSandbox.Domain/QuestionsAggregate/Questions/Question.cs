using System.Collections.Immutable;
using EFSandbox.Common;
using EFSandbox.Domain.QuestionsAggregate.Answers;

namespace EFSandbox.Domain.QuestionsAggregate.Questions;

public abstract partial class Question : Entity, IAggregateRoot
{
    public abstract QuestionType Type { get; protected set; }
    
    public QuestionTitle Title { get; }

    public QuestionDescription Description { get; }
    
    public CreatedAt CreatedAt { get; }
    
    private readonly List<Answer> _answers = [];
    public ImmutableList<Answer> Answers => _answers.ToImmutableList();

    // EF
    protected Question()
    {
    }

    protected Question(QuestionTitle title, QuestionDescription description) : base()
    {
        CreatedAt = CreatedAt.Create(DateTimeOffset.Now);
        
        Title = title;
        Description = description;
    }

    protected void Answer(Answer answer)
    {
        ArgumentNullException.ThrowIfNull(answer);
        
        _answers.Add(answer);
    }
}