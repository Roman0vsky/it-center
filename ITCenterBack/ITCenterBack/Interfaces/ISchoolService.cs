using ITCenterBack.Models;

namespace ITCenterBack.Interfaces
{
    public interface ISchoolService
    {
        Task CreateSchoolAsync(string name);
        Task DeleteSchoolAsync(long id);
        Task UpdateSchoolAsync(long id, string name);
        Task<School> GetSchoolAsync(long id);
        Task<List<School>> GetAllSchoolsAsync();
    }
}
