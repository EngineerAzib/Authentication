using Authentication.Data.VModel;
using Authentication.Data;
using Authentication.Migrations;
using Authentication.Data.Models;

namespace Authentication.Service
{
    public class StudentAttendence
    {
        private readonly DataContext _context;
        public StudentAttendence(DataContext context)
        {
            _context = context;
        }
        public async Task AddStudentAttendence(StudenAttendanceVM studenAttendance)
        {
            var std = new StudenAttendanceTable()
            {
                Student_Id = studenAttendance.Student_Id,
                dateTime = studenAttendance.dateTime,
                status = studenAttendance.status
            };
           _context.studenAttendanceTable.Add(std);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateStudentAttendence(int id,StudenAttendanceVM studenAttendance)
        {
            var std = _context.studenAttendanceTable.Find(id);
            std.Student_Id = studenAttendance.Student_Id;
            std.dateTime= studenAttendance.dateTime;
            std.status = studenAttendance.status;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteStudent(int id)
        {
            var std = _context.studenAttendanceTable.Find(id);
            _context.studenAttendanceTable.Remove(std);
            await _context.SaveChangesAsync();
        }
    }
}
