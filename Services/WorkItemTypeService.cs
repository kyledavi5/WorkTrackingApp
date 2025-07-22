using WorkTrackingApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using WorkTrackingApp.Data;

namespace WorkTrackingApp.Services
{
    // This service will handle operations related to WorkItems
    // such as fetching, creating, and updating work items.
    public class WorkItemTypeService
    {
        private readonly ApplicationDbContext _context;

        public WorkItemTypeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<WorkItemType>> GetAllAsync()
        {
            return await _context.WorkItemTypes.ToListAsync();
        }

        public async Task<WorkItemType> GetByIdAsync(int id)
        {
            return await _context.WorkItemTypes.FindAsync(id);
        }

        public async Task AddAsync(WorkItemType workItemType)
        {
            _context.WorkItemTypes.Add(workItemType);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateAsync(WorkItemType workItemType)
        {
            _context.WorkItemTypes.Update(workItemType);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var workItemType = await GetByIdAsync(id);
            if (workItemType != null)
            {
                _context.WorkItemTypes.Remove(workItemType);
                await _context.SaveChangesAsync();
            }
        }

        // Additional methods for filtering, sorting, etc. can be added here
        // For example, you might want to add methods to filter by type or status.
        

        // Add methods for create/update as needed
    }
}
