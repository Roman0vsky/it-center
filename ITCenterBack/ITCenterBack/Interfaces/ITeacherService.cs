using ITCenterBack.Models;

namespace ITCenterBack.Interfaces
{
    public interface ITeacherService
    {
        Task<List<Teacher>> GetAllAsync();
        Task CreateTeacherAsync(string name, string description, string image);
    }
}
