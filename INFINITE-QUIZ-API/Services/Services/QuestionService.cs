using INFINITE_QUIZ_API.DataProvider;
using INFINITE_QUIZ_API.Model.Dtos;
using INFINITE_QUIZ_API.Services.Interface;

namespace INFINITE_QUIZ_API.Services.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuizDal _dal;
        public QuestionService(IQuizDal dal)
        {
            _dal = dal;
        }

        public Task<IEnumerable<QuestionDto>> GetQuestionsByTechnologyAsync(string technology)
            => _dal.GetQuestionsByTechnologyAsync(technology);
    }

}
