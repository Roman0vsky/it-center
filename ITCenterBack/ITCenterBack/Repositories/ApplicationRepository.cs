using ITCenterBack.Data;
using ITCenterBack.Interfaces;
using ITCenterBack.Models;
using Microsoft.EntityFrameworkCore;

namespace ITCenterBack.Repositories
{
    public class ApplicationRepository : IRepository<Application>
    {
        private readonly ITCenterContext _context;

        public ApplicationRepository(ITCenterContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Application item)
        {
            await _context.Applications.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
			var application = await _context.Applications.FirstOrDefaultAsync(p => p.Id == id);

			if (application is not null)
			{
				_context.Applications.Remove(application);

				await _context.SaveChangesAsync();
			}
        }

        public async Task<List<Application>> GetAllAsync()
        {
            return await _context.Applications.OrderByDescending(p => p.Time).ToListAsync();
        }

        public async Task<Application> GetByIdAsync(long id)
        {
            return await _context.Applications.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(Application item)
        {
            _context.Applications.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
