namespace EFSandbox.Domain.QuestionsAggregate.Answers;

public partial class TextAnswer
{
    public record TextResponse
    {
        public const int MAX_LENGTH = 50;
        
        public string Value { get; }

        private TextResponse(string value)
        {
            Value = value;
        }

        public static TextResponse Create(string value)
        {
            ArgumentNullException.ThrowIfNull(value);

            if (value.Length > MAX_LENGTH)
                return null;
            
            return new(value);
        }
    }
}