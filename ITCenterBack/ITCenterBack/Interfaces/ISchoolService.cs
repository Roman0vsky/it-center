using ITCenterBack.Models;

namespace ITCenterBack.Interfaces
{
    public interface ISchoolService
    {
        Task CreateSchoolAsync(string name);
        Task DeleteSchoolAsync(long id);
        Task UpdateSchoolAsync(School school);
        Task<School> GetSchoolAsync(long id);
        Task<List<School>> GetAllSchoolsAsync();
    }
}
