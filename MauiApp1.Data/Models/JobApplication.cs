namespace MauiApp1.Data.Models
{
    public class JobApplication
    {
        public int Id { get; set; }
        public DateTime DateApplied { get; set; }
        public ApplicationStatus Status { get; set; }
        public string JobTitle { get; set; }
        public string URL { get; set; }

        public int ApplicationPageId { get; set; }
        public ApplicationPage ApplicationPage { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public ICollection<Tag> Tags { get; set; }
        public string TagList => Tags != null && Tags.Any() ? string.Join(", ", Tags.Select(t => t.Name)) : "—";
    }
}
