using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WorkTrackingApp.Data.Models;

namespace WorkTrackingApp.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<WorkItem> WorkItems { get; set; }
    public DbSet<WorkItemType> WorkItemTypes { get; set; }
    public DbSet<WorkItemCategory> WorkItemCategories { get; set; }
    public DbSet<WorkItemStatus> WorkItemStatuses { get; set; }

}

