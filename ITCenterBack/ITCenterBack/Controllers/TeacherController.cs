using AutoMapper;
using ITCenterBack.Interfaces;
using ITCenterBack.Models;
using ITCenterBack.Services;
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
        private readonly ISectionService _sectionService;
        private readonly IInfoService _infoService;
		private readonly IMapper _mapper;

        public TeacherController(ITeacherService teacherService, ICourseService courseService, ISocialLinkService linkService, ISectionService sectionService, 
            IInfoService infoService, IMapper mapper)
        {
            _teacherService = teacherService;
            _courseService = courseService;
            _linkService = linkService;
            _sectionService = sectionService;
            _infoService = infoService;
            _mapper = mapper;
        }

        [Route("AllTeachers")]
        public async Task<IActionResult> AllTeachersAsync()
        {
            var teachers = await _teacherService.GetAllAsync();
            var teachersVM = _mapper.Map<List<TeacherViewModel>>(teachers);

            var courses = new List<Course>();

            foreach (var t in teachersVM)
            {
                courses = await _teacherService.GetCoursesAsync(t.Id);
                t.Courses = _mapper.Map<List<CourseViewModel>>(courses);
            }

            var sections = await _sectionService.GetAllSections();
            var sectionsVM = _mapper.Map<List<SectionViewModel>>(sections);

            var links = await _linkService.GetAllSocialLinksAsync();
            var linksVM = _mapper.Map<List<SocialLinkViewModel>>(links);

			var info = await _infoService.GetInfoAsync();
			var infoVM = _mapper.Map<InfoViewModel>(info);

			var header = new HeaderViewModel
			{
				Sections = sectionsVM,
				Links = linksVM,
                Info = infoVM
            };

            var footer = new FooterViewModel
            {
                Info = infoVM
            };

            var page = new AllTeachersViewModel
            {
                Header = header,
                Teachers = teachersVM,
                Footer = footer
            };

            return View(page);
        }
    }
}
