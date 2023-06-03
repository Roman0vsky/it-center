using AutoMapper;
using ITCenterBack.Interfaces;
using ITCenterBack.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ITCenterBack.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NewsController : Controller
	{
		private readonly IMapper _mapper;
		private readonly ICourseService _courseService;
		//private readonly ISchoolService _schoolService;
		//private readonly ITeacherService _teacherService;
		private readonly INewsService _newsService;
        private readonly ISocialLinkService _linkService;

        public NewsController(IMapper mapper, ICourseService courseService, INewsService newsService, ISocialLinkService linkService)
        {
            _mapper = mapper;
            _courseService = courseService;
            _newsService = newsService;
            _linkService = linkService;
        }

        [Route("Details/{id}")]
		[ActionName("Details")]
		public async Task<IActionResult> DetailsAsync(long id)
		{
			var news = await _newsService.GetNewsAsync(id);
			if (news is not null)
			{
				var newsVM = _mapper.Map<NewsViewModel>(news);

				var courses = await _courseService.GetAllCoursesAsync();
				var coursesVM = _mapper.Map<List<CourseViewModel>>(courses);

                var links = await _linkService.GetAllSocialLinksAsync();
                var linksVM = _mapper.Map<List<SocialLinkViewModel>>(links);

                var header = new HeaderViewModel
                {
                    Courses = coursesVM,
                    Links = linksVM
                };

				var page = new NewsDetailsViewModel
				{
					Header = header,
					News = newsVM
				};

                return View(page);
			}

			return NotFound();
		}

        [Route("All")]
        [ActionName("All")]
        public async Task<IActionResult> AllNewsAsync()
		{
			var news = await _newsService.GetAllNewsAsync();
            var newsVM = _mapper.Map<List<NewsViewModel>>(news);

            var courses = await _courseService.GetAllCoursesAsync();
            var coursesVM = _mapper.Map<List<CourseViewModel>>(courses);

            var links = await _linkService.GetAllSocialLinksAsync();
            var linksVM = _mapper.Map<List<SocialLinkViewModel>>(links);

            var header = new HeaderViewModel
            {
                Courses = coursesVM,
                Links = linksVM
            };

            var page = new AllNewsViewModel
            {
                Header = header,
                News = newsVM
            };

            return View(page);
        }
	}	
}
