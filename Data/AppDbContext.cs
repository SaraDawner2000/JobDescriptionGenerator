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
            new JobFamily { JobFamilyId = 1, JobFamilyName = "Engineering", JobFamilyAlias = "ENG" },
            new JobFamily { JobFamilyId = 2, JobFamilyName = "Operations", JobFamilyAlias = "OPS" }
        );

        modelBuilder.Entity<JobTitle>()
            .HasIndex(j => new { j.JobFamilyId, j.JobLevel })
            .IsUnique();

        modelBuilder.Entity<JobTitle>().HasData(
            new JobTitle { JobTitleId = 1, JobTitleName = "Software Engineer", JobTitleCode = "SE1", JobFamilyId = 1, JobLevel = 4 },
            new JobTitle { JobTitleId = 2, JobTitleName = "Senior Software Engineer", JobTitleCode = "SE2", JobFamilyId = 1, JobLevel = 6 },
            new JobTitle { JobTitleId = 3, JobTitleName = "Operations Analyst", JobTitleCode = "OA1", JobFamilyId = 2, JobLevel = 5 },
            new JobTitle { JobTitleId = 4, JobTitleName = "Logistics Manager", JobTitleCode = "LM1", JobFamilyId = 2, JobLevel = 8 }
        );

    }
}
