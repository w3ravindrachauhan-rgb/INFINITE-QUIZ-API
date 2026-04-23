using INFINITE_QUIZ_API.Model.Dtos;

namespace INFINITE_QUIZ_API.DataProvider
{
    public interface IQuizDal
    {
        Task<IEnumerable<QuestionDto>> GetQuestionsByTechnologyAsync(string technology);
    }

}
