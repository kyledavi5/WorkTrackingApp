using WorkTrackingApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using WorkTrackingApp.Data;
using MudBlazor.Extensions;

namespace WorkTrackingApp.Services
{
    // This service will handle operations related to WorkItems
    // such as fetching, creating, and updating work items.
    public class WorkItemService
    {
        private readonly ApplicationDbContext _context;

        public WorkItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<WorkItem>> GetAllByUserIdAsync(string applicationUserId)
        {
            return await _context.WorkItems
                .Include(w => w.WorkItemType)
                .Include(w => w.WorkItemCategory)
                .Include(w => w.WorkItemStatus)
                .Where(w => w.ApplicationUserId == applicationUserId)
                .ToListAsync();
        }

        //public async Task<List<WorkItem>> GetAllWithActiveCategoriesAsync(string applicationUserId))
        //{
         //   return await _context.WorkItems
         //       .Include(w => w.WorkItemType)
          //      .Include(w => w.WorkItemCategory)
         //       .Include(w => w.WorkItemStatus)
         //       .Where(w => w.WorkItemCategory.IsActive)
           //     .ToListAsync();
        //}

        public async Task<List<WorkItem>> GetAllByUserIdAndCurrentWeekAsync(string applicationUserId)
        {
            var startOfWeek = DateTime.Now.StartOfWeek(DayOfWeek.Sunday);
            var endOfWeek = startOfWeek.AddDays(6);

            return await _context.WorkItems
                .Include(w => w.WorkItemType)
                .Include(w => w.WorkItemCategory)
                .Include(w => w.WorkItemStatus)
                .Where(w => w.StartDateTime >= startOfWeek && w.StartDateTime <= endOfWeek && w.ApplicationUserId == applicationUserId)
                .ToListAsync();
        }

        public async Task<WorkItem> GetByIdAsync(int id)
        {
            return await _context.WorkItems
                .Include(w => w.WorkItemType)
                .Include(w => w.WorkItemCategory)
                .Include(w => w.WorkItemStatus)
                .FirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task AddAsync(WorkItem workItem)
        {
            if (workItem.WorkItemType != null)
            {
                workItem.WorkItemTypeId = workItem.WorkItemType.Id;
                workItem.WorkItemType = null;
            }
            if (workItem.WorkItemCategory != null)
            {
                workItem.WorkItemCategoryId = workItem.WorkItemCategory.Id;
                workItem.WorkItemCategory = null;
            }
            if (workItem.WorkItemStatus != null)
            {
                workItem.WorkItemStatusId = workItem.WorkItemStatus.Id;
                workItem.WorkItemStatus = null;
            }
            _context.WorkItems.Add(workItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(WorkItem workItem)
        {
            _context.WorkItems.Update(workItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var workItem = await GetByIdAsync(id);
            if (workItem != null)
            {
                _context.WorkItems.Remove(workItem);
                await _context.SaveChangesAsync();
            }
        }

        // Additional methods for filtering, sorting, etc. can be added here
        // For example, you might want to add methods to filter by type or status.
        

        // Add methods for create/update as needed
    }
}
