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
			var course = await _context.Courses.FirstOrDefaultAsync(p => p.Id == id);

			if (course is not null)
			{
				_context.Courses.Remove(course);

				await _context.SaveChangesAsync();
			}
        }

        public async Task<List<Course>> GetAllAsync()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Course> GetByIdAsync(long id)
        {
            return await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(Course item)
        {
            _context.Courses.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
