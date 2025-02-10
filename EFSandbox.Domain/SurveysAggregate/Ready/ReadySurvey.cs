using Status = EFSandbox.Domain.SurveysAggregate.Survey.SurveyStatus;

namespace EFSandbox.Domain.SurveysAggregate.Ready;

public partial class ReadySurvey : Survey
{
    public override Status Status { get; protected set; } = Status.Ready;
    
    public ReadySurveySendingInformation SendingInformation { get; }
    
    public void Edit()
    {
        Status = Status.Draft;
    }

    public void Send()
    {
        Status = Status.Sent;
    }
}