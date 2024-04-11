using Authentication.Data.VModel;
using Authentication.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly Staff _staff;
        public StaffController(Staff staff)
        {
            _staff = staff;

        }
        [HttpPost("InsertStaff")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> AddStaff([FromForm] StaffVM staff, IFormFile imageFile)
        {
            await _staff.AddStaffAsync(staff, imageFile);
            return Ok();
        }

        [HttpGet("GetStaff")]
        public async Task<IActionResult> GetStaff()
        {
            var res = _staff.GetStaff();
            return Ok(res);
        }
        [HttpPut("UpdateStaff")]
        public async Task<IActionResult> UpdatePrograme([FromForm] StaffVM staff, int Id, IFormFile imageFile)
        {
            if (Id == 0)
            {
                return BadRequest();
            }
            await _staff.UpdateStaff(staff, imageFile,Id);
            return Ok();
        }
        [HttpDelete("DeleteStaff")]
        public async Task<IActionResult> DeleteStaff(int Id)
        {
            if (Id == 0)
            {
                return BadRequest();
            }
            
            await _staff.DeleteStaff(Id);
            return Ok();
        
    }
}
}
