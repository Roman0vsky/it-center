using ITCenterBack.Models;
using ITCenterBack.ViewModels;

namespace ITCenterBack.Interfaces
{
    public interface ITimeService
    {
        Task CreateTimeAsync(DateTime from, DateTime to);
        Task DeleteTimeAsync(long id);
        Task<List<Time>> GetTimesAsync();
        Task<Time> GetTimeAsync(long id);
    }
}
