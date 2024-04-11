using Microsoft.AspNetCore.Identity;

namespace Authentication.Data.Models
{
    public class Programetbl
    {
        public int ProgrameId { get; set; }

        

        public string Name { get; set; } = null!;

        public DateOnly StartDate { get; set; }

        public bool IsActive { get; set; }

       
    }
}
