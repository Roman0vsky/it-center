using ITCenterBack.Interfaces;
using ITCenterBack.Models;

namespace ITCenterBack.Services
{
    public class CourseService : ICourseService
    {
        private readonly IRepository<Course> _courseRepository;

        public CourseService(IRepository<Course> courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task CreateCourseAsync(string name, string age, string requirements, string description, string image)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                var course = new Course()
                {
                    Name = name,
                    Age = age,
                    Requirements = requirements,
                    Description = description,
                    Image = image
                };

                await _courseRepository.CreateAsync(course);
            }
        }

        public async Task DeleteCourseAsync(long courseId)
        {
            await _courseRepository.DeleteAsync(courseId);
        }

        public async Task<List<Course>> GetAllCoursesAsync()
        {
            var courses = await _courseRepository.GetAllAsync();

            return courses;
        }

        public async Task<Course> GetCourseAsync(long id)
        {
            return await _courseRepository.GetByIdAsync(id);
        }

        public async Task UpdateCourseAsync(long id, string name, string age, string requirements, string description, string image)
        {
            var course = await _courseRepository.GetByIdAsync(id);

            if(course is not null)
            {
                course.Name = name;
                course.Age = age;
                course.Description = description;
                course.Image = image;
                course.Requirements = requirements;

                await _courseRepository.UpdateAsync(course);
            }
        }
    }
}
