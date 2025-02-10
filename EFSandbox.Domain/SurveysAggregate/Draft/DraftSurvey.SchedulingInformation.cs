using EFSandbox.Common;

namespace EFSandbox.Domain.SurveysAggregate.Draft;

public partial class DraftSurvey
{
    public abstract class DraftSurveySchedulingInformation : Entity
    {
        public DateTimeOffset EndsAt { get; protected set; }

        // EF
        protected DraftSurveySchedulingInformation()
        {
        }

        public static DraftSurveySchedulingInformation ForLater(DateTimeOffset startsAt, DateTimeOffset endsAt)
        {
            return Later.Create(startsAt, endsAt);
        }

        public static DraftSurveySchedulingInformation ForImmediate(DateTimeOffset endsAt)
        {
            return Immediate.Create(endsAt);
        }
    }
    
    public class Later : DraftSurveySchedulingInformation
    {
        public DateTimeOffset StartsAt { get; }

        // EF
        private Later() : base()
        {
        }
            
        private Later(DateTimeOffset startsAt, DateTimeOffset endsAt)
        {
            StartsAt = startsAt;
            EndsAt = endsAt;
        }
            
        public static Later Create(DateTimeOffset startsAt, DateTimeOffset endsAt)
        {
            return new(startsAt, endsAt);
        }
    }

    public class Immediate : DraftSurveySchedulingInformation
    {
        // EF
        private Immediate() : base()
        {
        }

        private Immediate(DateTimeOffset endsAt)
        {
            EndsAt = endsAt;
        }

        public static Immediate Create(DateTimeOffset endsAt)
        {
            return new(endsAt);
        }
    }
}