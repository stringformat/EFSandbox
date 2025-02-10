namespace EFSandbox.Domain.SurveysAggregate.Draft;

public partial class DraftSurvey : Survey
{
    public override SurveyStatus Status { get; protected set; } = SurveyStatus.Draft;
    
    public DraftSurveySchedulingInformation SchedulingInformation { get; private set; }
    
    // EF
    private DraftSurvey()
    {
    }

    private DraftSurvey(SurveyTitle title) : base(title)
    {
    }
    
    public static DraftSurvey Create(string title)
    {
        return new (SurveyTitle.Create(title));
    }
    
    public void ScheduleImmediate(DateTimeOffset endsAt)
    {
        SchedulingInformation = DraftSurveySchedulingInformation.ForImmediate(endsAt);
    }
    
    public void ScheduleLater(DateTimeOffset startsAt, DateTimeOffset endsAt)
    {
        SchedulingInformation = DraftSurveySchedulingInformation.ForLater(startsAt, endsAt);
    }

    public void Validate()
    {
        if(_questions.Count < 1)
            return;
        
        Status = SurveyStatus.Ready;
    }
}