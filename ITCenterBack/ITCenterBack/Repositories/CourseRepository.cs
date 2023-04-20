using Microsoft.EntityFrameworkCore;
using ITCenterBack.Data;
using ITCenterBack.Interfaces;
using ITCenterBack.Models;

namespace ITCenterBack.Repositories
{
    public class CourseRepository : IRepository<Course>
    {
        private readonly ITCenterContext _context;

        public CourseRepository(ITCenterContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Course item)
        {
            await _context.Courses.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            _context.Remove(_context.Courses.FirstOrDefaultAsync(p => p.Id == id));
            await _context.SaveChangesAsync();
        }

        public Task<List<Course>> GetAllAsync()
        {
            return _context.Courses.ToListAsync();
        }

        public Task<Course> GetByIdAsync(long id)
        {
            return _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(Course item)
        {
            _context.Courses.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
