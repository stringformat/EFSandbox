namespace EFSandbox.Domain.SurveysAggregate;

public abstract partial class Survey
{
    public record SurveyTitle
    {
        public const int MAX_LENGTH = 20;
        
        public string Value { get; }

        private SurveyTitle(string value)
        {
            Value = value;
        }

        public static SurveyTitle Create(string value)
        {
            ArgumentNullException.ThrowIfNull(value);

            if (value.Length > MAX_LENGTH)
                return null;
            
            return new(value);
        }
    }
}