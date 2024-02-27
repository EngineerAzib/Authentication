using Authentication.Data.VModel;
using Authentication.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationController : ControllerBase
    {
        private Designation _designation;
        public DesignationController(Designation designation)
        {
            _designation = designation;
        }
        [HttpPost("PostDesignation")]
        public async Task<IActionResult> PostDesignation(DesignationVM designation)
        {
            await _designation.AddDesignation(designation);
            return Ok();
        }
        [HttpGet("GetDesignation")]
        public IActionResult GetDesignation()
        {
            var res=_designation.GetDesignations();
            return Ok(res);
        }
        [HttpPut("PutDesignation")]
        public async Task<IActionResult>UpdateDesig(int Id,DesignationVM designation)
        {
            if (Id==0)
            {
                return BadRequest();
            }
           await _designation.UpdateDesignation(Id, designation);
            return Ok();
        }
        [HttpDelete("UpdateDesignation")]
        public async Task<IActionResult> DeleteDeig(int Id)
        {
            if (Id == 0)
            {
                return BadRequest();
            }
           await _designation.DeleteDesignation(Id);
            return Ok();
        }
    }
}
