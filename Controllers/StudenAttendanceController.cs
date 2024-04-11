using Authentication.Data.VModel;
using Authentication.Migrations;
using Authentication.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudenAttendanceController : ControllerBase
    {
        private readonly StudentAttendence _studentAttendence;
        public StudenAttendanceController(StudentAttendence studentAttendance)
        {
            _studentAttendence = studentAttendance;
        }
     
        [HttpPost("studentAttendance")]

        public async Task<IActionResult> AddStudentAttendence(StudenAttendanceVM studenAttendance)
        {
            await _studentAttendence.AddStudentAttendence(studenAttendance);
            return Ok();
        }
        [HttpPut("UpdatestudentAttendance")]
        public async Task<IActionResult> UpdatestudentAttendence(int Id, StudenAttendanceVM studenAttendance)
        {
            if (Id == 0)
            {
                return BadRequest();
            }
            await _studentAttendence.UpdateStudentAttendence(Id, studenAttendance);
            return Ok();
        }
        [HttpDelete("DeletestudentAttendance")]
        public async Task<IActionResult> DeletestudentAttendence(int Id)
        {
            if (Id == 0)
            {
                return BadRequest();
            }
            await _studentAttendence.DeleteStudent(Id);
            return Ok();
        }
    }
}
