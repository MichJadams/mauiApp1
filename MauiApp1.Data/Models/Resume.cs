namespace MauiApp1.Data.Models
{
    public class Resume
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public string Summary { get; set; }

        public List<Education> Educations { get; set; } = new();

        public List<WorkHistory> WorkHistory { get; set; } = new();
    }
}
