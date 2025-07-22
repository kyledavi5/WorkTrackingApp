using Microsoft.EntityFrameworkCore;
using WorkTrackingApp.Data.Models;

namespace WorkTrackingApp.Data
{
    public static class DbInitializer
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            // Apply any pending migrations
            await context.Database.MigrateAsync();

            // Example: Seed WorkItemTypes if none exist
            if (!context.WorkItemTypes.Any())
            {
                context.WorkItemTypes.AddRange(
                    new WorkItemType { Name = "Activity" },
                    new WorkItemType { Name = "Call" },
                    new WorkItemType { Name = "Meeting" }
                );
            }

            // Example: Seed WorkItemStatuses if none exist
            if (!context.WorkItemStatuses.Any())
            {
                context.WorkItemStatuses.AddRange(
                    new WorkItemStatus { Name = "Active" },
                    new WorkItemStatus { Name = "Inactive" }
                );
            }

            // Example: Seed WorkItemCategories if none exist
            if (!context.WorkItemCategories.Any())
            {
                //context.WorkItemCategories.AddRange(
                //    new WorkItemCategory { Name = "Other" }
                //);
            }

            await context.SaveChangesAsync();
        }
    }
}