using ITCenterBack.Data;
using ITCenterBack.Interfaces;
using ITCenterBack.Models;
using Microsoft.EntityFrameworkCore;

namespace ITCenterBack.Repositories
{
    public class ApplicationTimeRepository : IRepository<ApplicationTime>
    {
        private readonly ITCenterContext _context;

        public ApplicationTimeRepository(ITCenterContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(ApplicationTime item)
        {
            await _context.ApplicationTimes.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var application = await _context.ApplicationTimes.FirstOrDefaultAsync(p => p.Id == id);

            if (application is not null)
            {
                _context.ApplicationTimes.Remove(application);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<ApplicationTime>> GetAllAsync()
        {
            return await _context.ApplicationTimes.ToListAsync();
        }

        public async Task<ApplicationTime> GetByIdAsync(long id)
        {
            return await _context.ApplicationTimes.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(ApplicationTime item)
        {
            _context.ApplicationTimes.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
