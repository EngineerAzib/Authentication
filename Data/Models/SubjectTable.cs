namespace Authentication.Data.Models
{
    public class SubjectTable
    {
        public int SubjectID { get; set; }
        public string Name { get; set; } = null!;
        public DateTime RegDate { get; set; } 
        public string Description { get; set; }
    }
}
