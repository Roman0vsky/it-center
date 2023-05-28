using AutoMapper;
using ITCenterBack.Models;
using ITCenterBack.ViewModels;

namespace ITCenterBack.Utilities
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<Course, CourseViewModel>();
            CreateMap<Teacher, TeacherViewModel>();
            CreateMap<School, SchoolViewModel>();
            CreateMap<News, NewsViewModel>();
			CreateMap<SocialLink, SocialLinkViewModel>();
            CreateMap<SliderImage, SliderImageViewModel>();
            CreateMap<Time, TimeViewModel>();
			CreateMap<AvaliableTime, AvaliableTimesViewModel>();
			CreateMap<Application, ApplicationViewModel>();
			CreateMap<Schedule, ScheduleViewModel>();
			CreateMap<AboutUs, AboutUsViewModel>();
			//CreateMap<List<Teacher>, TeachersViewModel>();
		}
    }
}
