namespace EFSandbox.Domain.SurveysAggregate;

public abstract partial class Survey
{
    public enum SurveyStatus
    {
        Draft,
        Ready,
        Sent,
        Close
    }
}