namespace WorkTrackingApp.Data.Models
{
    public class WorkItemCategory
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;

        public string ApplicationUserId { get; set; } // Foreign key
        public ApplicationUser ApplicationUser { get; set; } // Navigation property

    }
}