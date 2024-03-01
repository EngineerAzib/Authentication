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
        [HttpGet("GetSubject")]
        public async Task<IActionResult> GetSubject()
        {
            var res = _subject.GetSubject();
            return Ok(res);
        }
        [HttpPut("UpdateSubject")]
        public async Task<IActionResult>UpdateSubject(SubjecttblVM subject,int Id)
        {
            if (Id == 0)
            {
                return BadRequest();
            }
           await _subject.UpdateSubject(subject, Id);
            return Ok();
        }
        [HttpDelete("DeleteSubject")]
        public async Task<IActionResult>DeleteSubect(int Id)
        {
           await _subject.DeleteSubject(Id);
            return Ok();
        }
    }
}
