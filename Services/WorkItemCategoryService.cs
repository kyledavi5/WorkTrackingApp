using WorkTrackingApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using WorkTrackingApp.Data;

namespace WorkTrackingApp.Services
{
    // This service handles CRUD operations for WorkItemCategory entities.
    public class WorkItemCategoryService
    {
        private readonly ApplicationDbContext _context;

        public WorkItemCategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<WorkItemCategory>> GetAllAsync()
        {
            return await _context.WorkItemCategories.ToListAsync();
        }

        public async Task<WorkItemCategory?> GetByIdAsync(int id)
        {
            return await _context.WorkItemCategories.FindAsync(id);
        }

        public async Task AddAsync(WorkItemCategory category)
        {
            _context.WorkItemCategories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task<List<WorkItemCategory>> GetAllActiveByUserIdAsync(string applicationUserId)
        {
            return await _context.WorkItemCategories
                .Where(c => c.ApplicationUserId == applicationUserId && c.IsActive)
                .ToListAsync();
        }

        public async Task UpdateAsync(WorkItemCategory category)
        {
            _context.WorkItemCategories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await GetByIdAsync(id);
            if (category != null)
            {
                _context.WorkItemCategories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }
    }
}