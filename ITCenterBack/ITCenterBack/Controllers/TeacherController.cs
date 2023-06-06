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
		private readonly IInfoService _infoService;
		private readonly IMapper _mapper;

		public TeacherController(ITeacherService teacherService, ICourseService courseService, ISocialLinkService linkService, IInfoService infoService, IMapper mapper)
		{
			_teacherService = teacherService;
			_courseService = courseService;
			_linkService = linkService;
			_infoService = infoService;
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

			var info = await _infoService.GetInfoAsync();
			var infoVM = _mapper.Map<InfoViewModel>(info);

			var header = new HeaderViewModel
			{
				Courses = coursesVM,
				Links = linksVM,
				Logo = infoVM.HeaderLogo
			};

            var footer = new FooterViewModel
            {
                Links = linksVM,
                Logo = infoVM.FooterLogo,
                Adress = infoVM.AdressOfUniversity,
                NameOfUniversity = infoVM.NameOfUniversity
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
