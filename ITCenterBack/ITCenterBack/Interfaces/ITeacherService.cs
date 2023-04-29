using ITCenterBack.Models;

namespace ITCenterBack.Interfaces
{
    public interface ITeacherService
    {
        Task<List<Teacher>> GetAllAsync();
    }
}
