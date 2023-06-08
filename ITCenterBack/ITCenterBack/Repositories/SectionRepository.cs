using ITCenterBack.Data;
using ITCenterBack.Interfaces;
using ITCenterBack.Models;
using Microsoft.EntityFrameworkCore;

namespace ITCenterBack.Repositories
{
    public class SectionRepository : IRepository<Section>
    {
        private readonly ITCenterContext _context;

        public SectionRepository(ITCenterContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Section item)
        {
            await _context.Sections.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var school = await _context.Sections.FirstOrDefaultAsync(p => p.Id == id);

            if (school is not null)
            {
                _context.Sections.Remove(school);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Section>> GetAllAsync()
        {
            return await _context.Sections.ToListAsync();
        }

        public async Task<Section> GetByIdAsync(long id)
        {
            return await _context.Sections.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(Section item)
        {
            _context.Sections.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
