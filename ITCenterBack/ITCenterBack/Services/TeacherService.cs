using ITCenterBack.Interfaces;
using ITCenterBack.Models;

namespace ITCenterBack.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IRepository<Course> _courseRepository;

        public TeacherService(ITeacherRepository teacherRepository, IRepository<Course> courseRepository)
        {
            _teacherRepository = teacherRepository;
            _courseRepository = courseRepository;
        }

        public async Task CreateTeacherAsync(string name, string link, string image, List<long> coursesId)
		{
            var teacher = new Teacher
            {
                Name = name,
                Link = link,
                Image = image
            };

            if(coursesId is not null)
            {
				await _teacherRepository.CreateAsync(teacher, coursesId);
			}
            else
            {
				await _teacherRepository.CreateAsync(teacher);
			}
		}

		public async Task CreateTeacherAsync(string name, string link, string image)
		{
			var teacher = new Teacher
			{
				Name = name,
				Link = link,
				Image = image
			};

			await _teacherRepository.CreateAsync(teacher);
		}

		public async Task DeleteTeacherAsync(long id)
		{
            var teacher = await _teacherRepository.GetByIdAsync(id);

            if(teacher is not null)
            {
                await _teacherRepository.DeleteAsync(id);
            }
		}

		public async Task<List<Teacher>> GetAllAsync()
        {
            var teachers = await _teacherRepository.GetAllAsync();

            return teachers;
        }

		public async Task<List<Course>> GetCoursesAsync(long teacherId)
		{
            var teacherCourses = await _teacherRepository.GetCoursesAsync(teacherId);
            var courses = new List<Course>();

            foreach(var tc in teacherCourses)
            {
                courses.Add(await _courseRepository.GetByIdAsync(tc.CoursesId));
            }

            return courses;
		}

		public async Task<Teacher> GetTeacher(long id)
		{
			return await _teacherRepository.GetByIdAsync(id);
		}
	}
}
