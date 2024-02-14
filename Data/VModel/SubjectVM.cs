namespace Authentication.Data.VModel
{
    public class SubjectVM
    {
        public string Name { get; set; } = null!;
        public DateOnly RegDate { get; set; }
        public string Description { get; set; }
    }
}
