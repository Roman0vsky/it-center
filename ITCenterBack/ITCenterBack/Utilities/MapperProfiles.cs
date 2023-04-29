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
            //CreateMap<List<Teacher>, TeachersViewModel>();
        }
    }
}
