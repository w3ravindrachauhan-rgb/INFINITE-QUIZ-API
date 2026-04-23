using INFINITE_QUIZ_API.Model.Dtos;
using Microsoft.Data.SqlClient;
using System.Data;

namespace INFINITE_QUIZ_API.Repository
{
    public class QuizRepository : IQuizRepository
    {
        private readonly string _connectionString;
        public QuizRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<QuestionDto>> GetQuestionsByTechnologyAsync(string technology)
        {
            var questions = new List<QuestionDto>();
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand("GetQuestionsByTechnology", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Technology", technology);
                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        questions.Add(new QuestionDto
                        {
                            Id = reader.GetInt32(0),
                            Question = reader.GetString(1),
                            CorrectAnswer = reader.GetString(2),
                            Answers = reader.GetString(3).Split('|')
                        });
                    }
                }
            }
            return questions;
        }
    }
}
