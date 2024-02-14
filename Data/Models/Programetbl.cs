using Microsoft.AspNetCore.Identity;

namespace Authentication.Data.Models
{
    public class Programetbl
    {
        public int ProgrameId { get; set; }

        public string UserId { get; set; } = null!;

        public string Name { get; set; } = null!;

        public DateOnly StartDate { get; set; }

        public bool IsActive { get; set; }

        public virtual IdentityUser User { get; set; } = null!;
    }
}
