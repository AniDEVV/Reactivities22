using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Persistence;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        // Vendos connection string direkt ose nga environment variable
        optionsBuilder.UseSqlite("Data Source=reactivities.db");

        return new AppDbContext(optionsBuilder.Options);
    }
}
