using Status = EFSandbox.Domain.SurveysAggregate.Survey.SurveyStatus;

namespace EFSandbox.Domain.SurveysAggregate.Sent;

public class SentSurvey : Survey
{
    public override Status Status { get; protected set; } = Status.Sent;
    
    public void Close()
    {
        Status = Status.Close;
    }
}