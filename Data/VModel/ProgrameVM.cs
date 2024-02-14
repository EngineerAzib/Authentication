using Microsoft.AspNetCore.Identity;

namespace Authentication.Data.VModel
{
    public class ProgrameVM
    {

        public string UserId { get; set; } = null!;

        public string Name { get; set; } = null!;

        public DateOnly StartDate { get; set; }

        public bool IsActive { get; set; }


    }
    public class programeView {
     
        public string Name { get; set; } = null!;

        public DateOnly StartDate { get; set; }

        public bool IsActive { get; set; }


    }

}
