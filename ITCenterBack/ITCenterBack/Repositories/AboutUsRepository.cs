using ITCenterBack.Data;
using ITCenterBack.Interfaces;
using ITCenterBack.Models;
using Microsoft.EntityFrameworkCore;

namespace ITCenterBack.Repositories
{
    public class AboutUsRepository : IRepository<AboutUs>
    {
        private readonly ITCenterContext _context;

        public async Task CreateAsync(AboutUs item)
        {
            await _context.AboutUs.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var aboutUs = await _context.AboutUs.FirstOrDefaultAsync(p => p.Id == id);

            if (aboutUs is not null)
            {
                _context.AboutUs.Remove(aboutUs);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<AboutUs>> GetAllAsync()
        {
            return await _context.AboutUs.ToListAsync();
        }

        public async Task<AboutUs> GetByIdAsync(long id)
        {
            return await _context.AboutUs.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(AboutUs item)
        {
            _context.AboutUs.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
