using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Persistence
{
    public static class DbInitializer
    {
        public static async Task SeedData(AppDbContext context)
        {
            // Nëse ka të dhëna, nuk bëjmë gjë
            if (context.Activities.Any()) return;

            var activities = new List<Activity>
            {
                new Activity {
                    Title = "Past Activity 1",
                    MyProperty = "DefaultValue",
                    Date = DateTime.Now.AddMonths(-2),
                    Description = "Activity 2 months ago",
                    Category = "drinks",
                    City = "London",
                    Venue = "The Lamb and Flag, 33, Rose Street, Covent Garden, London",
                    Latitude = 51.51171665,
                    Longitude = -0.1256611057818921
                },
                new Activity {
                    Title = "Past Activity 2",
                    MyProperty = "DefaultValue",
                    Date = DateTime.Now.AddMonths(-1),
                    Description = "Activity 1 month ago",
                    Category = "culture",
                    City = "Paris",
                    Venue = "Louvre Museum, Rue Saint-Honoré, 1st Arrondissement, Paris",
                    Latitude = 48.8611473,
                    Longitude = 2.33802768704666
                },
                new Activity {
                    Title = "Future Activity 1",
                    MyProperty = "DefaultValue",
                    Date = DateTime.Now.AddMonths(1),
                    Description = "Activity 1 month in future",
                    Category = "culture",
                    City = "London",
                    Venue = "Natural History Museum",
                    Latitude = 51.4965109,
                    Longitude = -0.17600190725447445
                },
                new Activity {
                    Title = "Future Activity 2",
                    MyProperty = "DefaultValue",
                    Date = DateTime.Now.AddMonths(2),
                    Description = "Activity 2 months in future",
                    Category = "music",
                    City = "London",
                    Venue = "The O2",
                    Latitude = 51.50293665,
                    Longitude = 0.0032029278126681844
                },
                new Activity {
                    Title = "Future Activity 3",
                    MyProperty = "DefaultValue",
                    Date = DateTime.Now.AddMonths(3),
                    Description = "Activity 3 months in future",
                    Category = "drinks",
                    City = "London",
                    Venue = "The Mayflower",
                    Latitude = 51.501778,
                    Longitude = -0.053577
                },
                new Activity {
                    Title = "Future Activity 4",
                    MyProperty = "DefaultValue",
                    Date = DateTime.Now.AddMonths(4),
                    Description = "Activity 4 months in future",
                    Category = "drinks",
                    City = "London",
                    Venue = "The Blackfriar",
                    Latitude = 51.51214665,
                    Longitude = -0.10364680647106028
                },
                new Activity {
                    Title = "Future Activity 5",
                    MyProperty = "DefaultValue",
                    Date = DateTime.Now.AddMonths(5),
                    Description = "Activity 5 months in future",
                    Category = "culture",
                    City = "London",
                    Venue = "Sherlock Holmes Museum, 221b, Baker Street, London",
                    Latitude = 51.5237629,
                    Longitude = -0.1584743
                },
                new Activity {
                    Title = "Future Activity 6",
                    MyProperty = "DefaultValue",
                    Date = DateTime.Now.AddMonths(6),
                    Description = "Activity 6 months in future",
                    Category = "music",
                    City = "London",
                    Venue = "Roundhouse, Chalk Farm Road, London",
                    Latitude = 51.5432505,
                    Longitude = -0.15197608174931165
                },
                new Activity {
                    Title = "Future Activity 7",
                    MyProperty = "DefaultValue",
                    Date = DateTime.Now.AddMonths(7),
                    Description = "Activity 7 months in future",
                    Category = "travel",
                    City = "London",
                    Venue = "River Thames, London",
                    Latitude = 51.5575525,
                    Longitude = -0.781404
                },
                new Activity {
                    Title = "Future Activity 8",
                    MyProperty = "DefaultValue",
                    Date = DateTime.Now.AddMonths(8),
                    Description = "Activity 8 months in future",
                    Category = "film",
                    City = "London",
                    Venue = "River Thames, London",
                    Latitude = 51.5575525,
                    Longitude = -0.781404
                }
            };

            // 🔹 Ky është hapi i munguar:
            context.Activities.AddRange(activities);  // Shto listën në DbContext
            await context.SaveChangesAsync();         // Ruaj në databazë
        }
    }
}
