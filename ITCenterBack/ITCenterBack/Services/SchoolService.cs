using ITCenterBack.Interfaces;
using ITCenterBack.Models;

namespace ITCenterBack.Services
{
    public class SchoolService : ISchoolService
    {
        private readonly IRepository<School> _schoolRepository;

        public SchoolService(IRepository<School> schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        public async Task CreateSchoolAsync(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                var school1 = new School
                {
                    Name = name
                };

                await _schoolRepository.CreateAsync(school1);
            }
            
            //throw new Exception();
        }

        public async Task DeleteSchoolAsync(long id)
        {
            await _schoolRepository.DeleteAsync(id);
        }

        public async Task<List<School>> GetAllSchoolsAsync()
        {
            var schools = await _schoolRepository.GetAllAsync();

            return schools;
        }

        public async Task<School> GetSchoolAsync(long id)
        {
            return await _schoolRepository.GetByIdAsync(id);
        }

        public async Task UpdateSchoolAsync(School school)
        {
            if (school is not null)
            {
                await _schoolRepository.UpdateAsync(school);
            }

            //throw new Exception();
        }
    }
}
