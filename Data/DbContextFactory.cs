// This factory exists to support design-time features like migrations.
// EF Core uses it when there’s no running host (e.g., during `dotnet ef` commands).
// It ensures EF knows how to construct our AppDbContext with the correct options.

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace JobDescriptionGenerator.Data;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlite("Data Source=dev.db");

        return new AppDbContext(optionsBuilder.Options);
    }
}
