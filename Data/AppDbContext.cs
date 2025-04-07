using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<JobFamily> JobFamilies { get; set; }
    public DbSet<JobTitle> JobTitles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<JobFamily>().HasData(
            new JobFamily { JobFamilyId = 1, JobFamilyName = "Engineering" },
            new JobFamily { JobFamilyId = 2, JobFamilyName = "Operations" }
        );

        modelBuilder.Entity<JobTitle>().HasData(
            new JobTitle { JobTitleId = 1, JobTitleName = "Software Engineer", JobFamilyId = 1, JobLevelName = "Job Level - 4" },
            new JobTitle { JobTitleId = 2, JobTitleName = "Senior Software Engineer", JobFamilyId = 1, JobLevelName = "Job Level - 6" },
            new JobTitle { JobTitleId = 3, JobTitleName = "Operations Analyst", JobFamilyId = 2, JobLevelName = "Job Level - 5" },
            new JobTitle { JobTitleId = 4, JobTitleName = "Logistics Manager", JobFamilyId = 2, JobLevelName = "Job Level - 8" }
        );
    }
}
