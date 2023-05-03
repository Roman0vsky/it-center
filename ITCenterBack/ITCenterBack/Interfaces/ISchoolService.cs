using ITCenterBack.Models;

namespace ITCenterBack.Interfaces
{
    public interface ISchoolService
    {
        Task CreateSchoolAsync(School news);
        Task DeleteSchoolAsync(long id);
        Task UpdateSchoolAsync(School news);
        Task<School> GetSchoolAsync(long id);
        Task<List<School>> GetAllSchoolsAsync();
    }
}
