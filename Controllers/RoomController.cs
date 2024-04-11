using Authentication.Data.VModel;
using Authentication.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly Room _room;
        public RoomController(Room room)
        {
            _room = room;

        }
        [HttpPost("InsertRoom")]
        public async Task<IActionResult> AddRoom(RoomVM room)
        {
            await _room.AddRoom(room);
            return Ok();
        }
        [HttpGet("GetRoom")]
        public async Task<IActionResult> GetRoom()
        {
            var res = _room.GetRoom();
            return Ok(res);
        }
        [HttpPut("UpdateSession")]
        public async Task<IActionResult> UpdateSession([FromBody] RoomVM room, int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            await _room.UpdateRoom(id, room);
            return Ok();
        }

        [HttpDelete("DeleteRoom")]
        public async Task<IActionResult> DeleteRoom(int Id)
        {
            if (Id == 0)
            {
                return BadRequest();
            }
            await _room.DeleteRoom(Id);
            return Ok();

        }
    }
}
