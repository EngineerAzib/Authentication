using Authentication.Data.VModel;
using Authentication.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly Student _student;
        public StudentController(Student student)
        {
            _student = student;
        }

        [HttpPost("student")]
        public async Task<IActionResult> RegisterUserAsync([FromForm] StudentView studentView)
        {
            await _student.RegisterUserAsync(studentView.registration, studentView.student, studentView.imageFile);
            return Ok();
        }

        [HttpPut("student")]
        public async Task<IActionResult> UpdateStudentAsync(string userId, [FromForm] StudentView studentView)
        {
            var result = await _student.UpdateUserAsync(userId, studentView.registration, studentView.student, studentView.imageFile);

            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }


        [HttpDelete("DeleteStudent")]
        public async Task<IActionResult> DeleteStudentAsync(string userId)
        {
            var result = await _student.DeleteUserAsync(userId);

            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }



    }
}