using ITCenterBack.Models;

namespace ITCenterBack.Interfaces
{
    public interface IApplicationService
    {
        Task CreateApplication(long? schoolId, string? schoolName, int clas, string phoneNumber, string listenerFullName, string representativeFullName, 
            string representativePhoneNumber, List<Time> times, List<Course> courses);
        Task DeleteApplication(long id);
        Task UpdateApplication();
        Task<List<Application>> GetAll();
    }
}
