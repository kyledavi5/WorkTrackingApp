using WorkTrackingApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using WorkTrackingApp.Data;

namespace WorkTrackingApp.Services
{
    // This service handles CRUD operations for WorkItemStatus entities.
    public class WorkItemStatusService
    {
        private readonly ApplicationDbContext _context;

        public WorkItemStatusService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<WorkItemStatus>> GetAllAsync()
        {
            return await _context.Set<WorkItemStatus>().ToListAsync();
        }

        public async Task<WorkItemStatus?> GetByIdAsync(int id)
        {
            return await _context.Set<WorkItemStatus>().FindAsync(id);
        }

        public async Task AddAsync(WorkItemStatus status)
        {
            _context.Set<WorkItemStatus>().Add(status);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(WorkItemStatus status)
        {
            _context.Set<WorkItemStatus>().Update(status);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var status = await GetByIdAsync(id);
            if (status != null)
            {
                _context.Set<WorkItemStatus>().Remove(status);
                await _context.SaveChangesAsync();
            }
        }
    }
}