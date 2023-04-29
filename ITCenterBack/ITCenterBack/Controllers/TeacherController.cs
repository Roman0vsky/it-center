using AutoMapper;
using ITCenterBack.Interfaces;
using ITCenterBack.Models;
using ITCenterBack.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ITCenterBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;

        public TeacherController(ITeacherService teacherService, IMapper mapper, ICourseService courseService)
        {
            _teacherService = teacherService;
            _mapper = mapper;
            _courseService = courseService;
        }

        [Route("AllTeachers")]
        public async Task<IActionResult> AllTeachersAsync()
        {
            var teachers = await _teacherService.GetAllAsync();
            var teachersVM = _mapper.Map<List<TeacherViewModel>>(teachers);

            var courses = await _courseService.GetAllCoursesAsync();
            var coursesVM = _mapper.Map<List<CourseViewModel>>(courses);

            var page = new AllTeachersViewModel
            {
                Header = new HeaderViewModel
                {
                    Courses = coursesVM,
                },
                Teachers = teachersVM
            };

            return View(page);
        }
    }
}
