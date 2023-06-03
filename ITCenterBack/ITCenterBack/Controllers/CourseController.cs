using AutoMapper;
using ITCenterBack.Constants;
using ITCenterBack.Interfaces;
using ITCenterBack.Models;
using ITCenterBack.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITCenterBack.Controllers
{
    //[Authorize(Policy = AccountPolicies.ElevatedRights)]
    //[AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly ISocialLinkService _linkService;
        private readonly IInfoService _infoService;
        private readonly IMapper _mapper;

		public CourseController(ICourseService courseService, ISocialLinkService linkService, IInfoService infoService, IMapper mapper)
		{
			_courseService = courseService;
			_linkService = linkService;
			_infoService = infoService;
			_mapper = mapper;
		}

		[HttpGet]
        [Route("Details/{id}")]
        //[ActionName("Details")]
        public async Task<IActionResult> DetailsAsync(long id)
        {
            var course = await _courseService.GetCourseAsync(id);
            if (course is not null)
            {
                var courseVM = _mapper.Map<CourseViewModel>(course);

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

                var page = new CourseDetailsViewModel
                {
                    Course = courseVM,
                    Header = header,
                    Footer = footer
                };

                return View(page);
            }

            return NotFound();
        }

        //public async Task<IActionResult> AllCoursesAsync()
        //{
        //    var courses = await _courseService.GetAllCoursesAsync();
        //    var coursesVM = _mapper.Map<List<CourseViewModel>>(courses);

        //    return View();
        //}

        //public async Task<IActionResult> _HeaderAsync()
        //{
        //    var courses = await _courseService.GetAllCoursesAsync();
        //    var coursesVM = _mapper.Map<List<CourseViewModel>>(courses);

        //    ViewBag.Courses = coursesVM;

        //    return View();
        //}
    }
}
