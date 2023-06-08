using AutoMapper;
using ITCenterBack.Constants;
using ITCenterBack.Interfaces;
using ITCenterBack.Models;
using ITCenterBack.Services;
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
        private readonly ISectionService _sectionService;
        private readonly IMapper _mapper;

        public CourseController(ICourseService courseService, ISocialLinkService linkService, IInfoService infoService, ISectionService sectionService, IMapper mapper)
        {
            _courseService = courseService;
            _linkService = linkService;
            _infoService = infoService;
            _sectionService = sectionService;
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
    }
}
