using AutoMapper;
using ITCenterBack.Interfaces;
using ITCenterBack.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ITCenterBack.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SquareController : Controller
	{
		private readonly ISocialLinkService _linkService;
		private readonly ISectionService _sectionService;
		private readonly IInfoService _infoService;
		private readonly IWebHostEnvironment _appEnvironment;
		private readonly IMapper _mapper;

		public SquareController(ISocialLinkService linkService, ISectionService sectionService, IInfoService infoService, IWebHostEnvironment appEnvironment, IMapper mapper)
		{
			_linkService = linkService;
			_sectionService = sectionService;
			_infoService = infoService;
			_appEnvironment = appEnvironment;
			_mapper = mapper;
		}

		[HttpGet]
		[Route("Details/{id}")]
		[ActionName("Details")]
		public async Task<IActionResult> DetailsAsync(long id)
		{
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

			var page = new SquareDetailsViewModel
			{
				Header = header,
				Footer = footer
			};

            return View(page);
        }
	}
}
