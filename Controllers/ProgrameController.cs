using Authentication.Data.VModel;
using Authentication.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrameController : ControllerBase
    {
        private readonly Programe _programe;
        public ProgrameController(Programe programe)
        {
            _programe=programe;

        }
        [HttpPost("InsertPrograme")]
        public async Task<IActionResult> AddPrograme(ProgrameVM programe) {
            await _programe.AddPrograme(programe);
            return Ok();
        }
        [HttpGet("GetPrograme")]
        public async Task<IActionResult>GetPrograme()
        {
            var res = _programe.GetPrograme();
            return Ok(res);
        }
        [HttpPut("UpdatePrograme/{id}")]
        public async Task<IActionResult> UpdatePrograme(programeView programe,int Id)
        {
            if (Id==0)
            {
                return BadRequest();
            }
            await _programe.UpdatePrograme(programe, Id);
            return Ok();
        }
        [HttpDelete("DeletePrograme/{id}")]
        public async Task<IActionResult>DeletePrograme(int Id)
        {
            if (Id == 0)
            {
                return BadRequest();
            }
            await _programe.DeletePrograme(Id);
            return Ok();
        }
    }
}
