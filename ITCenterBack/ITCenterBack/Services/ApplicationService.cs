using ITCenterBack.Interfaces;
using ITCenterBack.Models;
using ITCenterBack.ViewModels;
using ITCenterBack.ViewModels.SecondaryViewModels;
using System.Globalization;
using System.Runtime.InteropServices;

namespace ITCenterBack.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IRepository<Application> _applicationRepository;
        private readonly IRepository<Course> _courseRepository;
        private readonly IApplicationTimeRepository _appTimeRepository;
        private readonly IRepository<School> _schoolRepository;
        private readonly IRepository<AvaliableTime> _avTimeRepository;
		private readonly IRepository<Time> _timeRepository;
		private readonly ICourseApplicationRepository _courseApplRepository;

		public ApplicationService(IRepository<Application> applicationRepository, IRepository<Course> courseRepository, IApplicationTimeRepository appTimeRepository, 
            IRepository<School> schoolRepository, IRepository<AvaliableTime> avTimeRepository, IRepository<Time> timeRepository, ICourseApplicationRepository courseApplRepository)
		{
			_applicationRepository = applicationRepository;
			_courseRepository = courseRepository;
			_appTimeRepository = appTimeRepository;
			_schoolRepository = schoolRepository;
			_avTimeRepository = avTimeRepository;
			_timeRepository = timeRepository;
			_courseApplRepository = courseApplRepository;
		}

		public async Task CreateApplication(string? schoolName, int clas, string listenerFullName, string representativeFullName, 
            string representativePhoneNumber, List<AvaliableTime> times, List<long> coursesId)
        {
            var application = new Application()
            {
                SchoolName = schoolName,
                Class = clas,
                ListenerFullName = listenerFullName,
                RepresentativeFullName = representativeFullName,
                RepresentativePhoneNumber = representativePhoneNumber
            };

			await _applicationRepository.CreateAsync(application);

            await CreateCoursesAndTimeConnectionsAsync(times, coursesId, application);
        }

		public async Task CreateApplication(long? schoolId, int clas, string listenerFullName, string representativeFullName, string representativePhoneNumber, 
            List<AvaliableTime> times, List<long> coursesId)
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

            await CreateCoursesAndTimeConnectionsAsync(times, coursesId, application);
        }

        private async Task CreateCoursesAndTimeConnectionsAsync(List<AvaliableTime> times, List<long> coursesId, Application application)
        {
            foreach (var id in coursesId)
            {
                await _courseApplRepository.CreateAsync(
                    new CourseApplication
                    {
                        CourseId = id,
                        ApplicationId = application.Id
                    });
            }

            foreach (var t in times)
            {
                await _appTimeRepository.CreateAsync(
                    new ApplicationTime
                    {
                        TimeId = t.TimeId,
                        ApplicationId = application.Id,
                        Day = t.Day
                    }
                    );
            }
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
            var timeApp = await _appTimeRepository.GetByApplicationIdAsync(id);
            var courses = new List<string>();
            //var times = new List<Time>();
            //var days = new List<DayOfWeek>();
            Course course;
            Time time;

            var daysTimes = new List<TimeDayViewModel>();

			foreach (var courseApp in coursesApp)
            {
                course = await _courseRepository.GetByIdAsync(courseApp.CourseId);
                if(course is not null)
                {
					courses.Add(course.Name);
				}
            }

            foreach (var t in timeApp)
            {
                time = await _timeRepository.GetByIdAsync(t.TimeId);

                if(time is not null)
                {
                    daysTimes.Add(new TimeDayViewModel
                    {
                        TimeFrom = time.From,
                        TimeTo = time.To,
                        Day = CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat.GetDayName(t.Day)
				    });
				}
            }

            applicationVM.SchoolName = application.SchoolName;
            applicationVM.ListenerFullName = application.ListenerFullName;
            applicationVM.RepresentativePhoneNumber = application.RepresentativePhoneNumber;
            applicationVM.RepresentativeFullName = application.RepresentativeFullName;
            applicationVM.Courses = courses;
            applicationVM.Class = application.Class;
            applicationVM.DayTime = daysTimes;

            return applicationVM;
        }

        //to do
        public Task UpdateApplication()
        {
            throw new NotImplementedException();
        }
    }
}
