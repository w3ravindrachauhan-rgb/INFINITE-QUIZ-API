namespace INFINITE_QUIZ_API.Model.Dtos
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string CorrectAnswer { get; set; }
        public string[] Answers { get; set; }
    }

}
