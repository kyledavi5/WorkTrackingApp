using System.ComponentModel.DataAnnotations;

namespace WorkTrackingApp.Data.Models;

public class WorkItemType
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;
}
