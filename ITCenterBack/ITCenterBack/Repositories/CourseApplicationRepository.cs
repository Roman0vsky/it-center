using ITCenterBack.Data;
using ITCenterBack.Interfaces;
using ITCenterBack.Models;
using Microsoft.EntityFrameworkCore;

namespace ITCenterBack.Repositories
{
    public class CourseApplicationRepository : ICourseApplicationRepository
    {
        private readonly ITCenterContext _context;

        public CourseApplicationRepository(ITCenterContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(CourseApplication item)
        {
            await _context.CourseApplications.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var time = await _context.CourseApplications.FirstOrDefaultAsync(p => p.Id == id);

            if (time is not null)
            {
                _context.CourseApplications.Remove(time);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<CourseApplication>> GetAllAsync()
        {
            return await _context.CourseApplications.ToListAsync();
        }

        public async Task<List<CourseApplication>> GetByApplicationId(long applicationId)
        {
            return await _context.CourseApplications.Where(u => u.ApplicationId == applicationId).ToListAsync();
        }

        public async Task<CourseApplication> GetByIdAsync(long id)
        {
            return await _context.CourseApplications.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(CourseApplication item)
        {
            _context.CourseApplications.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
