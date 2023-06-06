using ITCenterBack.Data;
using ITCenterBack.Interfaces;
using ITCenterBack.Models;
using Microsoft.EntityFrameworkCore;

namespace ITCenterBack.Repositories
{
    public class SchoolRepository : IRepository<School>
    {
        private readonly ITCenterContext _context;

        public SchoolRepository(ITCenterContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(School item)
        {
            await _context.Schools.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
			var school = await _context.Schools.FirstOrDefaultAsync(p => p.Id == id);

			if (school is not null)
			{
				_context.Schools.Remove(school);

				await _context.SaveChangesAsync();
			}
        }

        public async Task<List<School>> GetAllAsync()
        {
            return await _context.Schools.ToListAsync();
        }

        public async Task<School> GetByIdAsync(long id)
        {
            return await _context.Schools.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(School item)
        {
            _context.Schools.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
