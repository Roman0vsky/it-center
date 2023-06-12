using ITCenterBack.Models;

namespace ITCenterBack.Interfaces
{
    public interface ICourseService
    {
        Task CreateCourseAsync(string name, string age, string requirements, string description, string image);
        Task DeleteCourseAsync(long courseId);
        Task UpdateCourseAsync(Course course);
        Task<Course> GetCourseAsync(long id);
        Task<List<Course>> GetAllCoursesAsync();
    }
}
