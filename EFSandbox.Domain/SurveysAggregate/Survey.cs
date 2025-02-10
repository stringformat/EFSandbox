using System.Collections.Immutable;
using EFSandbox.Common;
using EFSandbox.Domain.SurveysAggregate.Draft;
using Status = EFSandbox.Domain.SurveysAggregate.Survey.SurveyStatus;

namespace EFSandbox.Domain.SurveysAggregate;

public abstract partial class Survey : Entity, IAggregateRoot
{
    public abstract Status Status { get; protected set; }

    public SurveyTitle Title { get; }

    public CreatedAt CreatedAt { get; }
    
    protected readonly List<SurveyQuestion> _questions = [];
    public ImmutableList<SurveyQuestion> Questions => _questions.ToImmutableList();
    
    // EF
    protected Survey()
    {
    }

    protected Survey(SurveyTitle title) : base()
    {
        CreatedAt = CreatedAt.Create(DateTimeOffset.Now);
        Status = Status.Draft;

        Title = title;
    }
}