namespace EFSandbox.Domain.SurveysAggregate.Ready;

public partial class ReadySurvey
{
    public record ReadySurveySendingInformation(DateTimeOffset StartsAt, DateTimeOffset EndsAt);
}