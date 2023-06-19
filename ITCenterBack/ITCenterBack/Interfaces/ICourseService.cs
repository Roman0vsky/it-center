using ITCenterBack.Models;

namespace ITCenterBack.Interfaces
{
    public interface ICourseService
    {
        Task CreateCourseAsync(string name, string age, string requirements, string description, string image);
        Task DeleteCourseAsync(long courseId);
        Task UpdateCourseAsync(long id, string name, string age, string requirements, string description, string image);
        Task<Course> GetCourseAsync(long id);
        Task<List<Course>> GetAllCoursesAsync();
    }
}
