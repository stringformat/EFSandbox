namespace EFSandbox.Domain.QuestionsAggregate.Questions.MultipleChoice;

public partial class MultipleChoiceQuestion
{
    public partial class Option
    {
        public record OptionTitle(string Value);
    }
}