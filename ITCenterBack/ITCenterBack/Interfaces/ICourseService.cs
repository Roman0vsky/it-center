using ITCenterBack.Models;

namespace ITCenterBack.Interfaces
{
    public interface ICourseService
    {
        Task CreateCourseAsync(Course course);
        Task DeleteCourseAsync(long courseId);
        Task UpdateCourseAsync(Course course);
        Task<Course> GetCourseAsync(long id);
        Task<List<Course>> GetAllCoursesAsync();
    }
}
