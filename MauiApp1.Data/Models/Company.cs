namespace MauiApp1.Data.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string? CompanyName { get; set; }

        public ICollection<JobApplication> Applications { get; set; }
    }
}