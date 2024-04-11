using Authentication.Data.VModel;
using Authentication.Data;
using Microsoft.AspNetCore.Identity;
using Authentication.Data.Models;

namespace Authentication.Service
{
    public class Room
    {
        private readonly DataContext _context;
        public Room(DataContext context)
        {
            _context = context;
        }
        public async Task AddRoom(RoomVM room)
        {
            var room1 = new RoomTable()
            {
                RoomNo = room.RoomNo,
                Title = room.Title,
                Description = room.Description,
            };

            _context.roomTables.Add(room1);
            await _context.SaveChangesAsync();
        }
        public List<RoomVM> GetRoom()
        {
            var res = _context.roomTables.Select(D => new RoomVM
            {
               RoomNo=D.RoomNo,
               Title=D.Title,
               Description=D.Description,
            }).ToList();
            return res;
        }
        public async Task UpdateRoom(int Id, RoomVM room)
        {
            var sesupdate = _context.roomTables.Find(Id);
            sesupdate.RoomNo=room.RoomNo;
            sesupdate.Title=room.Title;
            sesupdate.Description=room.Description;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteRoom(int Id)
        {
            var res = _context.roomTables.Find(Id);
            _context.roomTables.Remove(res);
            await _context.SaveChangesAsync();
        }
    }
}
