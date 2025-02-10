using EFSandbox.Application.Questions;
using EFSandbox.Domain.QuestionsAggregate.Questions;
using EFSandbox.Infrastructure.Common;

namespace EFSandbox.Infrastructure.Questions;

public class QuestionRepository(Context context) : RepositoryBase<Question>(context), IQuestionRepository;