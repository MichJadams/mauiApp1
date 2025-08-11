namespace MauiApp1.Data.Models
{
    public class WorkHistory
    {
        public int Id { get; set; }
        public string JobTitle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public int ResumeId { get; set; }
        public Resume Resume { get; set; }
    }
}
