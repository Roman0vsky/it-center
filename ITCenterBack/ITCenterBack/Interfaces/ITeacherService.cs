using ITCenterBack.Models;

namespace ITCenterBack.Interfaces
{
    public interface ITeacherService
    {
        Task<List<Teacher>> GetAllAsync();
        Task CreateTeacherAsync(string name, string link, string image, List<long> coursesId);
		Task CreateTeacherAsync(string name, string link, string image);
		Task DeleteTeacherAsync(long id);
		Task<List<Course>> GetCoursesAsync(long teacherId);
		Task<Teacher> GetTeacher(long id);
    }
}
