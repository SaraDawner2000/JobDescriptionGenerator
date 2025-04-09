using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<JobFamily> JobFamilies { get; set; }
    public DbSet<JobTitle> JobTitles { get; set; }
    public DbSet<JobLevel> JobLevels { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<JobLevel>().HasData(
            new JobLevel { JobLevelId = 4, JobLevelName = "Job Level - 4" },
            new JobLevel { JobLevelId = 5, JobLevelName = "Job Level - 5" },
            new JobLevel { JobLevelId = 6, JobLevelName = "Job Level - 6" },
            new JobLevel { JobLevelId = 7, JobLevelName = "Job Level - 7" },
            new JobLevel { JobLevelId = 8, JobLevelName = "Job Level - 8" },
            new JobLevel { JobLevelId = 9, JobLevelName = "Job Level - 9" },
            new JobLevel { JobLevelId = 10, JobLevelName = "Job Level - 10" },
            new JobLevel { JobLevelId = 11, JobLevelName = "Job Level - 11" }
        );

        modelBuilder.Entity<JobFamily>().HasData(
            new JobFamily { JobFamilyId = 1, JobFamilyName = "Engineering", JobFamilyAlias = "ENG" },
            new JobFamily { JobFamilyId = 2, JobFamilyName = "Operations", JobFamilyAlias = "OPS" }
        );

        modelBuilder.Entity<JobTitle>().HasData(
            new JobTitle { JobTitleId = 1, JobTitleName = "Software Engineer", JobTitleCode = "SE1", JobFamilyId = 1, JobLevelId = 4 },
            new JobTitle { JobTitleId = 2, JobTitleName = "Senior Software Engineer", JobTitleCode = "SE2", JobFamilyId = 1, JobLevelId = 6 },
            new JobTitle { JobTitleId = 3, JobTitleName = "Operations Analyst", JobTitleCode = "OA1", JobFamilyId = 2, JobLevelId = 5 },
            new JobTitle { JobTitleId = 4, JobTitleName = "Logistics Manager", JobTitleCode = "LM1", JobFamilyId = 2, JobLevelId = 8 }
        );

    }
}
