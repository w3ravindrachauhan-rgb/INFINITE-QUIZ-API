using INFINITE_QUIZ_API.Model.Dtos;
using INFINITE_QUIZ_API.Repository;

namespace INFINITE_QUIZ_API.DataProvider
{
    public class QuizDal : IQuizDal
    {
        private readonly IQuizRepository _repository;
        public QuizDal(IQuizRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<QuestionDto>> GetQuestionsByTechnologyAsync(string technology)
            => _repository.GetQuestionsByTechnologyAsync(technology);
    }

}
