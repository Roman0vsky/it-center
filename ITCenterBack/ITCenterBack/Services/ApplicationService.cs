using ITCenterBack.Interfaces;
using ITCenterBack.Models;

namespace ITCenterBack.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IRepository<Application> _applicationRepository;
        private readonly IRepository<Course> _courseRepository;
        private readonly IRepository<School> _schoolRepository;

        public ApplicationService(IRepository<Application> applicationRepository, IRepository<Course> courseRepository, IRepository<School> schoolRepository)
        {
            _applicationRepository = applicationRepository;
            _courseRepository = courseRepository;
            _schoolRepository = schoolRepository;
        }

        public Task CreateApplication(long? schoolId, string? schoolName, int clas, string phoneNumber, string listenerFullName, 
            string representativeFullName, string representativePhoneNumber, List<Time> times, List<Course> courses)
        {
            //if(!string.IsNullOrWhiteSpace(listenerFullName) && !string.IsNullOrWhiteSpace(representativeFullName))
            //{

            //}
            throw new NotImplementedException();
        }

        public Task DeleteApplication(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Application>> GetAll()
        {
            return await _applicationRepository.GetAllAsync();
        }

        public Task UpdateApplication()
        {
            throw new NotImplementedException();
        }
    }
}
