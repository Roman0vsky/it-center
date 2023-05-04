using AutoMapper;
using ITCenterBack.Constants;
using ITCenterBack.Interfaces;
using ITCenterBack.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITCenterBack.Controllers
{
    [Authorize(Policy = AccountPolicies.ElevatedRights, AuthenticationSchemes = "Identity.Application,Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICourseService _courseService;
        private readonly ISchoolService _schoolService;
        private readonly INewsService _newsService;
        private readonly ITeacherService _teacherService;

        public AdminController(IMapper mapper, ICourseService courseService, ISchoolService schoolService, INewsService newsService)
        {
            _mapper = mapper;
            _courseService = courseService;
            _schoolService = schoolService;
            _newsService = newsService;
        }

		[Route("Teachers")]
		public async Task<IActionResult> TeachersAsync()
        {
            var teachers = await _teacherService.GetAllAsync();
            var teachersVM = _mapper.Map<List<TeacherViewModel>>(teachers);

            return View(teachersVM);
        }

		[Route("Schools")]
		public async Task<IActionResult> SchoolsAsync()
		{
			var schools = await _schoolService.GetAllSchoolsAsync();
			var schoolsVM = _mapper.Map<List<SchoolViewModel>>(schools);

			return View(schoolsVM);
		}
	}
}
