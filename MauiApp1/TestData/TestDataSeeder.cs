using MauiApp1.Data;
using MauiApp1.Data.Models;

namespace MauiApp1.TestData
{
    public static class TestDataSeeder
    {
        public static void SeedTestData(ApplyDbContext db)
        {
            if (db.Applications.Any()) return;

            var company = new Company
            {
                CompanyName = "Cyberdyne Systems",
            };

            var workhistory = new WorkHistory
            {
                JobTitle = "Intern",
                StartDate = new DateTime(2022, 1, 1),
                EndDate = new DateTime(2022, 12, 31),
                ResumeId = 1
            };

            var page = new ApplicationPage
            {
                JobPostingUrl = "https://fake.jobs/terminator",
                PostingPage = "<html><body>This is a fake job</body></html>"
            };

            var application = new JobApplication
            {
                JobTitle = "AI Research Assistant",
                URL = "https://fake.jobs/terminator",
                DateApplied = DateTime.Today,
                Status = ApplicationStatus.Applied,
                Company = company,
                Tags = [new Tag { Name = "AI" }],
                ApplicationPage = page
            };

            var application2 = new JobApplication
            {
                JobTitle = "Senior Software Engineer",
                URL = "https://fake.jobs/terminator",
                DateApplied = DateTime.Today.AddDays(-10),
                Status = ApplicationStatus.Interviewing,
                Company = company,
                Tags = [new Tag { Name = "DreamJob" }, new Tag { Name = "Hard" }, new Tag { Name = "FollowUp" }],
                ApplicationPage = page
            };

            db.Applications.Add(application);
            db.Applications.Add(application2);

            db.SaveChanges();
        }
    }
}
