using INFINITE_QUIZ_API.Model.Dtos;

namespace INFINITE_QUIZ_API.Repository
{
    public interface IQuizRepository
    {
        Task<IEnumerable<QuestionDto>> GetQuestionsByTechnologyAsync(string technology);
    }
}
