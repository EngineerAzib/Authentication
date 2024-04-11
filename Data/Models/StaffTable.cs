using Microsoft.AspNetCore.Identity;

namespace Authentication.Data.Models
{
    public class StaffTable
    {
        public int Id { get; set; }
        public int Designation_ID { get; set; }
        public string Name { get; set; }
        public string ContactNo { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string Qualification { get; set; }
        public string PhotoPath { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public virtual DesignationTable DesignationTable { get; set; } = null!;
    }
}
