using MauiApp1.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MauiApp1.Data
{
    public class ApplyDbContext : DbContext
    {
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Company> Companies { get; set; }

        public DbSet<JobApplication> Applications { get; set; }
        public DbSet<WorkHistory> WorkHistories { get; set; }

        private string _dbPath;

        public ApplyDbContext()
        {
            var folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            _dbPath = Path.Combine(folder, "applyLocalInformationTwo.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resume>()
                .HasMany(r => r.Educations)
                .WithOne(e => e.Resume)
                .HasForeignKey(e => e.ResumeId);

            modelBuilder.Entity<Resume>()
                .HasMany(r => r.WorkHistory)
                .WithOne(c => c.Resume)
                .HasForeignKey(c => c.ResumeId);

            modelBuilder.Entity<JobApplication>(entity =>
            {
                entity.HasKey(a => a.Id);

                entity.Property(a => a.JobTitle).IsRequired();
                entity.Property(a => a.URL).IsRequired();
                entity.Property(a => a.DateApplied).IsRequired();

                entity.HasOne(a => a.Company)
                      .WithMany(c => c.Applications)
                      .HasForeignKey(a => a.CompanyId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(a => a.ApplicationPage)
                      .WithMany()
                      .HasForeignKey(a => a.ApplicationPageId);
            });

            modelBuilder.Entity<WorkHistory>(entity =>
            {
                entity.HasKey(w => w.Id);

                entity.HasOne(a => a.Company)
                    .WithMany()
                    .HasForeignKey(a => a.CompanyId);
                entity.HasOne(w => w.Resume)
                    .WithMany()
                    .HasForeignKey(w => w.ResumeId);
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.CompanyName).IsRequired();
            });

            modelBuilder.Entity<ApplicationPage>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.JobPostingUrl).IsRequired();
                entity.Property(p => p.PostingPage).HasColumnType("TEXT");
            });

            modelBuilder.Entity<JobApplication>()
                .Property(a => a.Status)
                .HasConversion<string>();
        }

    }
}
