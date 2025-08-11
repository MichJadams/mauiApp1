namespace MauiApp1.Data.Models
{
    public class Tag
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public ICollection<JobApplication> JobApplications { get; set; } = new List<JobApplication>();

    }
}