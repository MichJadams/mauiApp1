namespace MauiApp1.Data.Models
{
    public class Education
    {
        public int Id { get; set; }
        public string SchoolName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Major { get; set; }

        public string Degree   { get; set; }


        public int ResumeId { get; set; }
        public Resume Resume { get; set; }
    }
}