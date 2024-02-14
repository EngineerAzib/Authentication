using Authentication.Data.VModel;
using Authentication.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class SubjectController : ControllerBase
    {
        private readonly Subject _subject;
        public SubjectController(Subject subject)
        {
            _subject = subject;
        }

        [HttpPost("PostSubject")]
        public async Task<IActionResult> PostSubject(SubjecttblVM subject)
        {
            await _subject.PostSubject(subject);
            return Ok();
        }
    }
}
