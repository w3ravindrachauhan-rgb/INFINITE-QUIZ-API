using INFINITE_QUIZ_API.Model.Dtos;

namespace INFINITE_QUIZ_API.Services.Interface
{
    public interface IQuestionService
    {
        Task<IEnumerable<QuestionDto>> GetQuestionsByTechnologyAsync(string technology);
    }
}
