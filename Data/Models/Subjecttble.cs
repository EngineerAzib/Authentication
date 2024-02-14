namespace Authentication.Data.Models
{
    public class Subjecttble
    {
        public int SubjectID { get; set; }
        public string Name { get; set; } = null!;
        public DateTime RegDate { get; set; }
        public string Description { get; set; }
    }
}
