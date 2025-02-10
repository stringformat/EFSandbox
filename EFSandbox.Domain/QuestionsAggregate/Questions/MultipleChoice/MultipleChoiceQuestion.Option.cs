using EFSandbox.Common;

namespace EFSandbox.Domain.QuestionsAggregate.Questions.MultipleChoice;

public partial class MultipleChoiceQuestion
{
    public partial class Option : Entity
    {
        public string Title { get; }

        // EF
        private Option()
        {
        }

        private Option(string title) : base()
        {
            Title = title;
        }

        public static Option Create(string title)
        {
            return new(title);
        }
    }
}