using ITCenterBack.Models;

namespace ITCenterBack.Interfaces
{
    public interface IApplicationTimeService
    {
        Task<List<ApplicationTime>> GetByApplicationIdAsync(long appId);
        Task CreateAsync(long appId, long timeId);
        Task UpdateTime(long appId, List<Time> times);
    }
}
