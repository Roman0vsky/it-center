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
        private readonly ISocialLinkService _linkService;
        private readonly IMapper _mapper;

        public TeacherController(ITeacherService teacherService, ICourseService courseService, ISocialLinkService linkService, IMapper mapper)
        {
            _teacherService = teacherService;
            _courseService = courseService;
            _linkService = linkService;
            _mapper = mapper;
        }

        [Route("AllTeachers")]
        public async Task<IActionResult> AllTeachersAsync()
        {
            var teachers = await _teacherService.GetAllAsync();
            var teachersVM = _mapper.Map<List<TeacherViewModel>>(teachers);

            var courses = await _courseService.GetAllCoursesAsync();
            var coursesVM = _mapper.Map<List<CourseViewModel>>(courses);

            var links = await _linkService.GetAllSocialLinksAsync();
            var linksVM = _mapper.Map<List<SocialLinkViewModel>>(links);

            var page = new HeaderViewModel
            {
                Courses = coursesVM,
                Links = linksVM
            };

            return View(page);
        }
    }
}
