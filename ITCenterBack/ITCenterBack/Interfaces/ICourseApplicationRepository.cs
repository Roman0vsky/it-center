using ITCenterBack.Models;

namespace ITCenterBack.Interfaces
{
    public interface ICourseApplicationRepository : IRepository<CourseApplication>
    {
        Task<List<CourseApplication>> GetByApplicationId(long applicationId);
    }
}
