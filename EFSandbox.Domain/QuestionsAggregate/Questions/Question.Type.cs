namespace EFSandbox.Domain.QuestionsAggregate.Questions;

public abstract partial class Question
{
    public enum QuestionType
    {
        Text,
        MultipleChoice
    }
}