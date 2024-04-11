using Authentication.Data.VModel;
using Authentication.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly Session _session;
        public SessionController(Session session)
        {
            _session = session;

        }
        [HttpPost("InsertSession")]
        public async Task<IActionResult> AddSession(SessionVM session)
        {
            await _session.AddSession(session);
            return Ok();
        }
        [HttpGet("GetSession")]
        public async Task<IActionResult> GetSession()
        {
            var res = _session.GetSession();
            return Ok(res);
        }
        [HttpPut("UpdateSession")]
        public async Task<IActionResult>UpdateSession([FromBody] SessionVM session, int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            await _session.UpdateSession(id, session);
            return Ok();
        }
    
    [HttpDelete("DeleteSession")]
        public async Task<IActionResult> DeleteSession(int Id)
        {
            if (Id == 0)
            {
                return BadRequest();
            }
            await _session.DeleteSession(Id);
            return Ok();
        
    }
}
}
