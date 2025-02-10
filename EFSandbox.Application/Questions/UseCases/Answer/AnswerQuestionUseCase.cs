using EFSandbox.Application.Users;
using EFSandbox.Common;
using EFSandbox.Domain.QuestionsAggregate.Answers;
using EFSandbox.Domain.QuestionsAggregate.Questions;
using EFSandbox.Domain.QuestionsAggregate.Questions.MultipleChoice;

namespace EFSandbox.Application.Questions.UseCases.Answer;

public class AnswerQuestionUseCase(IQuestionRepository questionRepository, IUserRepository userRepository, IUnitOfWork unitOfWork)
{
    public async Task<Response> HandleAsync(Request request, CancellationToken cancellationToken)
    {
        if (!await questionRepository.ExistAsync(request.QuestionId, cancellationToken))
            return null;
        
        if (!await userRepository.ExistAsync(request.UserId, cancellationToken))
            return null;
            
        var question = await questionRepository.FindAsync(request.QuestionId, cancellationToken);
        var user = await userRepository.FindAsync(request.UserId, cancellationToken);

        switch (question)
        {
            case TextQuestion textQuestion:
                textQuestion.Answer(request.Response, user);
                break;
            
            case MultipleChoiceQuestion multipleChoiceQuestion:
                multipleChoiceQuestion.Answer(request.OptionId, user);
                break;
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new();
    }

    public record Request(int QuestionId, int UserId, string Response, int OptionId);

    public record Response();
}