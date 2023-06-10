using ITCenterBack.Models;

namespace ITCenterBack.Interfaces
{
	public interface ITeacherRepository : IRepository<Teacher>
	{
		Task CreateAsync(Teacher teacher, List<long> coursesId);
		Task<List<TeacherCourses>> GetCoursesAsync(long teacherId);
	}
}
