using ITCenterBack.Models;

namespace ITCenterBack.Interfaces
{
    public interface ISectionService
    {
        Task CreateSectionAsync(string name, string description, string image);
        Task DeleteSectionAsync(long id);
        Task<Section> GetSectionAsync(long id);
        Task<List<Section>> GetAllSections();
    }
}
