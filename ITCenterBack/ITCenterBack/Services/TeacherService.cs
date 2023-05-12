using ITCenterBack.Interfaces;
using ITCenterBack.Models;

namespace ITCenterBack.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly IRepository<Teacher> _teacherRepository;

        public TeacherService(IRepository<Teacher> teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

		public async Task CreateTeacherAsync(string name, string description, string image)
		{
            var teacher = new Teacher
            {
                Name = name,
                Description = description,
                Image = image
            };

            await _teacherRepository.CreateAsync(teacher);
		}

		public async Task<List<Teacher>> GetAllAsync()
        {
            var teachers = await _teacherRepository.GetAllAsync();

            return teachers;
        }
    }
}
