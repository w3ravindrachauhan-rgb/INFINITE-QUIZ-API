using INFINITE_QUIZ_API.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace INFINITE_QUIZ_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService _service;
        public QuestionsController(IQuestionService service)
        {
            _service = service;
        }

        [HttpGet("{technology}")]
        public async Task<IActionResult> GetQuestionsByTechnology(string technology)
        {
            if (string.IsNullOrWhiteSpace(technology))
                return BadRequest("Technology is required.");

            var questions = await _service.GetQuestionsByTechnologyAsync(technology);
            return Ok(questions);
        }
    }

}
