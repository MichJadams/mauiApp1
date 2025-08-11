using MauiApp1.Data;
using MauiApp1.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MauiApp1.Services
{
    public class ApplyService
    {
        private readonly ApplyDbContext _db;

        public ApplyService()
        {
            _db = new ApplyDbContext();
        }

        public async Task<List<Company>> GetJobs()
        {
            return await _db.Companies.AsNoTracking().ToListAsync();
        }

        public async Task SaveResumeAsync(
            string name,
            string address,
            string summary)
        {

            var resume = new Resume
            {
                Name = name,
                Address = address,
                Summary = summary,
                Educations = new List<Education>(),
                WorkHistory = new List<WorkHistory>()
            };

            _db.Resumes.Add(resume);
            await _db.SaveChangesAsync();
        }

        public async Task<List<JobApplication>> GetApplications()
        {
            return await _db.Applications
                .Include(a => a.Company)
                .Include(a => a.Tags)
                .AsNoTracking().ToListAsync();
        }

        public async Task SaveOrUpdateJobAsync(string jobTitle,string company, DateTime selectedStartDate, DateTime selectedEndDate)
        {
            var jobApplication = new JobApplication
            {
                JobTitle = jobTitle,
                Company = new Company { CompanyName = company },
                DateApplied = selectedStartDate
            };

            _db.Applications.Add(jobApplication);
            await _db.SaveChangesAsync();
        }

        public async Task SaveOrUpdateJobAsync(JobApplication jobApplication)
        {
            _db.Applications.Add(jobApplication);
            await _db.SaveChangesAsync();
        }
    }

}
