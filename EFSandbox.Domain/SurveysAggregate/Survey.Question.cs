using EFSandbox.Domain.QuestionsAggregate.Questions;

namespace EFSandbox.Domain.SurveysAggregate;

public abstract partial class Survey
{
    public record SurveyQuestion
    {
        public int SurveyId { get; }
        public Survey Survey { get; }
        
        public int QuestionId { get; }
        public Question Question { get; }
        
        public int Order { get; }

        // EF
        private SurveyQuestion()
        {
        }

        public SurveyQuestion(Survey survey, Question question, int order)
        {
            Survey = survey;
            SurveyId = survey.Id;
            
            Question = question;
            QuestionId = question.Id;
            
            Order = order;
        }
    }
}