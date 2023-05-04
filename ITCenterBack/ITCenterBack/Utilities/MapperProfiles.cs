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
            //CreateMap<List<Teacher>, TeachersViewModel>();
        }
    }
}
