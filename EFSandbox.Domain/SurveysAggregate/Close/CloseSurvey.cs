using Status = EFSandbox.Domain.SurveysAggregate.Survey.SurveyStatus;

namespace EFSandbox.Domain.SurveysAggregate.Close;

public class CloseSurvey : Survey
{
    public override Status Status { get; protected set; } = Status.Close;
}