using Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapControllers();
//
// ---------------------------
// Seed database safely
// ---------------------------
await SeedDatabaseAsync(app);

app.Run();


// ---------------------------
// Async helper function
// ---------------------------
async Task SeedDatabaseAsync(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;

    try
    {
        var context = services.GetRequiredService<AppDbContext>();
        await context.Database.MigrateAsync(); // Applies migrations
        await DbInitializer.SeedData(context); // Adds initial data

        var dbFile = Path.Combine(Directory.GetCurrentDirectory(), "reactivities.db");
        Console.WriteLine(File.Exists(dbFile) 
            ? $"Database created at: {dbFile}" 
            : "Database not found!");
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred during migrations");
    }
}
