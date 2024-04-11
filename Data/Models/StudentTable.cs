using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Authentication.Data.Models
{
    public class StudentTable
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int Session_ID { get; set; }
        public int Programe_ID { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public DateOnly DateofBirth { get; set; }
        public string Gender { get; set; }

        public string ContactNo { get; set; }
        public string PreviousSchool { get; set; }
        public string Photo { get; set; }
        public DateOnly ApplyDate { get; set; }
        public string PreviousPercentage { get; set; }
        
        public string Address { get; set; }
       

        public virtual IdentityUser User { get; set; } = null!;
        public virtual Sessiontable Sessiontable { get; set; } = null!;
        public virtual Programetbl Programetbl { get; set; } = null!;
    }
}
