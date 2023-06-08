using AutoMapper;
using ITCenterBack.Interfaces;
using ITCenterBack.Services;
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
        private readonly ISectionService _sectionService;
        private readonly INewsService _newsService;
        private readonly ISocialLinkService _linkService;
		private readonly IInfoService _infoService;

        public NewsController(IMapper mapper, ICourseService courseService, ISectionService sectionService, INewsService newsService, ISocialLinkService linkService, 
            IInfoService infoService)
        {
            _mapper = mapper;
            _courseService = courseService;
            _sectionService = sectionService;
            _newsService = newsService;
            _linkService = linkService;
            _infoService = infoService;
        }

        [Route("Details/{id}")]
		[ActionName("Details")]
		public async Task<IActionResult> DetailsAsync(long id)
		{
			var news = await _newsService.GetNewsAsync(id);
			if (news is not null)
			{
				var newsVM = _mapper.Map<NewsViewModel>(news);

                var sections = await _sectionService.GetAllSections();
                var sectionsVM = _mapper.Map<List<SectionViewModel>>(sections);

                var links = await _linkService.GetAllSocialLinksAsync();
                var linksVM = _mapper.Map<List<SocialLinkViewModel>>(links);

				var info = await _infoService.GetInfoAsync();
				var infoVM = _mapper.Map<InfoViewModel>(info);

                var footer = new FooterViewModel
                {
                    Info = infoVM
                };

                var header = new HeaderViewModel
				{
					Sections = sectionsVM,
					Links = linksVM,
                    Info = infoVM
                };

				var page = new NewsDetailsViewModel
				{
					Header = header,
					News = newsVM,
					Footer = footer
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

            var page = new AllNewsViewModel
            {
                Header = header,
                News = newsVM,
				Footer = footer
            };

            return View(page);
        }
	}	
}
