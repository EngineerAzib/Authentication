using Authentication.Migrations;

namespace Authentication.Data.Models
{
    public class StudenAttendanceTable
    {
      public int Id { get; set; }
        public int Student_Id { get; set; }
        public DateTime dateTime { get; set; }
        public string status { get; set; }
        public virtual StudentTable StudentTable { get; set; } = null!;
    }

}
