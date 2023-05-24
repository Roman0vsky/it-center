using ITCenterBack.Models;
using ITCenterBack.ViewModels;

namespace ITCenterBack.Interfaces
{
    public interface IApplicationService
    {
        Task CreateApplication(string? schoolName, int clas, string listenerFullName, string representativeFullName, 
            string representativePhoneNumber, List<Time> times, List<long> coursesId);
        Task DeleteApplication(long id);
        Task UpdateApplication();
        Task<List<Application>> GetAll();
        Task<ApplicationDetailsViewModel> GetApplication(long id);
    }
}
