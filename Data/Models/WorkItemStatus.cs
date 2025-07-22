namespace WorkTrackingApp.Data.Models
{
    public class WorkItemStatus
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;

    }
}