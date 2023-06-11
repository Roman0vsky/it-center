using AutoMapper;
using ITCenterBack.Models;
using ITCenterBack.ViewModels;
using ITCenterBack.ViewModels.BasicViewModels;

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
			CreateMap<Info, InfoViewModel>();
            CreateMap<Section, SectionViewModel>();
			CreateMap<Square, SquareViewModel>();
			CreateMap<Administration, AdministrationViewModel>();
			//CreateMap<List<Teacher>, TeachersViewModel>();
		}
    }
}
