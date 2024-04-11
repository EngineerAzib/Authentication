using Authentication.Data.VModel;
using Microsoft.AspNetCore.Identity.Data;

namespace Authentication.Data.VModel
{
    public class StudentVM
    {
        public int Session_ID { get; set; }

        public int Programe_ID { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public DateOnly DateofBirth { get; set; }
        public string Gender { get; set; }

        public string ContactNo { get; set; }
        public string PreviousSchool { get; set; }
     
        public DateOnly ApplyDate { get; set; }
        public string PreviousPercentage { get; set; }

        public string Address { get; set; }

    }
    public class StudentView
    {
       public StudentVM student { get; set; }
        public RegisterRequest registration { get; set; }
        public IFormFile imageFile { get; set; }
    }
}
public class UpdateUserRequest
{
    public RegisterRequest Registration { get; set; }
    public StudentVM StudentVM { get; set; }
    public IFormFile imageFile { get; set; }
}
