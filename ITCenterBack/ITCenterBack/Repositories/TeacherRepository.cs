using ITCenterBack.Data;
using ITCenterBack.Interfaces;
using ITCenterBack.Models;
using Microsoft.EntityFrameworkCore;

namespace ITCenterBack.Repositories
{
    public class TeacherRepository : ITeacherRepository
	{
        private readonly ITCenterContext _context;

        public TeacherRepository(ITCenterContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Teacher item)
        {
            await _context.Teachers.AddAsync(item);
            await _context.SaveChangesAsync();
        }

		public async Task CreateAsync(Teacher teacher, List<long> coursesId)
		{
			await _context.Teachers.AddAsync(teacher);

			await _context.SaveChangesAsync();

			foreach (var id in coursesId)
            {
                await _context.TeacherCourses.AddAsync(
                    new TeacherCourses 
                    { 
                        CoursesId = id,
                        TeacherId = teacher.Id
                    });
            }

			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(long id)
        {
            var teacher = await _context.Teachers.FirstOrDefaultAsync(p => p.Id == id);

            if(teacher is not null)
            {
                _context.Teachers.Remove(teacher);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Teacher>> GetAllAsync()
        {
            return await _context.Teachers.ToListAsync();
        }

        public async Task<Teacher> GetByIdAsync(long id)
        {
            return await _context.Teachers.FirstOrDefaultAsync(c => c.Id == id);
        }

		public async Task<List<TeacherCourses>> GetCoursesAsync(long teacherId)
		{
            return await _context.TeacherCourses.Where(n => n.TeacherId == teacherId).ToListAsync();
		}

		public async Task UpdateAsync(Teacher item)
        {
            _context.Teachers.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
