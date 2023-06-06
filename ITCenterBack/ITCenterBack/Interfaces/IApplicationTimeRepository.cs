using ITCenterBack.Models;

namespace ITCenterBack.Interfaces
{
    public interface IApplicationTimeRepository : IRepository<ApplicationTime>
    {
        Task<List<ApplicationTime>> GetByApplicationIdAsync(long appId);
    }
}
