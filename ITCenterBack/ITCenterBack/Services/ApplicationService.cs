using ITCenterBack.Interfaces;
using ITCenterBack.Models;
using ITCenterBack.ViewModels;

namespace ITCenterBack.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IRepository<Application> _applicationRepository;
        private readonly IRepository<Course> _courseRepository;
        private readonly IRepository<School> _schoolRepository;
        private readonly ICourseApplicationRepository _courseApplRepository;

        public ApplicationService(IRepository<Application> applicationRepository, IRepository<Course> courseRepository, IRepository<School> schoolRepository, ICourseApplicationRepository courseApplRepository)
        {
            _applicationRepository = applicationRepository;
            _courseRepository = courseRepository;
            _schoolRepository = schoolRepository;
            _courseApplRepository = courseApplRepository;
        }

        //to do
        public async Task CreateApplication(string? schoolName, int clas, string listenerFullName, string representativeFullName, 
            string representativePhoneNumber, List<Time> times, List<long> coursesId)
        {
            var application = new Application()
            {
                SchoolName = schoolName,
                Class = clas,
                ListenerFullName = listenerFullName,
                RepresentativeFullName = representativeFullName,
                RepresentativePhoneNumber = representativePhoneNumber
            };

			//if (string.IsNullOrEmpty(schoolId))
			//{
   //             application.SchoolName = schoolName;
			//}
   //         else
   //         {
   //             var id = long.Parse(schoolId);
   //             var school = await _schoolRepository.GetByIdAsync(id);

   //             application.SchoolName = school.Name;
   //         }

			await _applicationRepository.CreateAsync(application);

            foreach (var id in coursesId)
            {
                await _courseApplRepository.CreateAsync(
                    new CourseApplication
                    {
                        CourseId = id,
                        ApplicationId = application.Id
                    });
            }

            //throw new NotImplementedException();
        }

		public async Task CreateApplication(long? schoolId, int clas, string listenerFullName, string representativeFullName, string representativePhoneNumber, List<Time> times, List<long> coursesId)
		{
			var application = new Application()
			{
				Class = clas,
				ListenerFullName = listenerFullName,
				RepresentativeFullName = representativeFullName,
				RepresentativePhoneNumber = representativePhoneNumber
			};

			var school = new School();

			if (schoolId.HasValue)
            {
                school = await _schoolRepository.GetByIdAsync((long)schoolId);
			}

			application.SchoolName = school.Name;

			await _applicationRepository.CreateAsync(application);

			foreach (var id in coursesId)
			{
				await _courseApplRepository.CreateAsync(
					new CourseApplication
					{
						CourseId = id,
						ApplicationId = application.Id
					});
			}

			//throw new NotImplementedException();
		}

		//to do
		public Task DeleteApplication(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Application>> GetAll()
        {
            return await _applicationRepository.GetAllAsync();
        }

        public async Task<ApplicationDetailsViewModel> GetApplication(long id)
        {
            var applicationVM = new ApplicationDetailsViewModel();

            var application = await _applicationRepository.GetByIdAsync(id);
            var coursesApp = await _courseApplRepository.GetByApplicationId(id);
            var courses = new List<string>();
            Course course;

            foreach (var courseApp in coursesApp)
            {
                course = await _courseRepository.GetByIdAsync(courseApp.CourseId);

                courses.Add(course.Name);
            }

            applicationVM.SchoolName = application.SchoolName;
            applicationVM.RepresentativePhoneNumber = application.RepresentativePhoneNumber;
            applicationVM.RepresentativeFullName = application.RepresentativeFullName;
            applicationVM.Courses = courses;
            applicationVM.Class = application.Class;

            return applicationVM;
        }

        //to do
        public Task UpdateApplication()
        {
            throw new NotImplementedException();
        }
    }
}
