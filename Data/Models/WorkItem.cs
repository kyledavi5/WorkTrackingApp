using System;

namespace WorkTrackingApp.Data.Models
{
    public class WorkItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsCompleted { get; set; } = false;
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public DateTime? StartDateTime { get; set; }
        public DateTime? FinishDateTime { get; set; }
        
        public int WorkItemCategoryId { get; set; } // Foreign key
        public WorkItemCategory? WorkItemCategory { get; set; } // Navigation property

        public int WorkItemStatusId { get; set; } // Foreign key
        public WorkItemStatus? WorkItemStatus { get; set; } // Navigation property

        public int WorkItemTypeId { get; set; } // Foreign key
        public WorkItemType? WorkItemType { get; set; } // Navigation property

        public string ApplicationUserId { get; set; } // Foreign key
        public ApplicationUser ApplicationUser { get; set; } // Navigation property
    }
}