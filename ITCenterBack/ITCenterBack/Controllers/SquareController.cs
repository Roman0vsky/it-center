using AutoMapper;
using ITCenterBack.Constants;
using ITCenterBack.Interfaces;
using ITCenterBack.ViewModels;
using ITCenterBack.ViewModels.AddViewModels;
using Microsoft.AspNetCore.Authorization;
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
		private readonly ISquareService _squareService;
		private readonly IWebHostEnvironment _appEnvironment;
		private readonly IMapper _mapper;

		public SquareController(ISocialLinkService linkService, ISectionService sectionService, IInfoService infoService, ISquareService squareService, 
			IWebHostEnvironment appEnvironment, IMapper mapper)
		{
			_linkService = linkService;
			_sectionService = sectionService;
			_infoService = infoService;
			_squareService = squareService;
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

			var square = await _squareService.GetSquareAsync(id);
			var squareVM = _mapper.Map<SquareViewModel>(square);

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
				Footer = footer,
				Square = squareVM
			};

            return View(page);
        }

		[HttpGet]
		[Route("All")]
		[ActionName("All")]
		[Authorize(Policy = AccountPolicies.ElevatedRights, AuthenticationSchemes = "Identity.Application,Bearer")]
		public async Task<IActionResult> AllAsync()
		{
			var square = await _squareService.GetAllSquares();
			var squareVM = _mapper.Map<List<SquareViewModel>>(square);

			return View(squareVM);
		}

		[HttpGet]
		[ActionName("Add")]
		[Route("Add")]
		[Authorize(Policy = AccountPolicies.ElevatedRights, AuthenticationSchemes = "Identity.Application,Bearer")]
		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		[ActionName("Add")]
		[Route("Add")]
		[Authorize(Policy = AccountPolicies.ElevatedRights, AuthenticationSchemes = "Identity.Application,Bearer")]
		public async Task<IActionResult> PostAddAsync([FromForm] AddSquareViewModel viewModel, IFormFile uploadedFile)
		{
			if (uploadedFile != null)
			{
				string path = "/images/squares/" + uploadedFile.FileName;

				using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
				{
					await uploadedFile.CopyToAsync(fileStream);
				}

				if (!string.IsNullOrEmpty(viewModel.Title) && !string.IsNullOrEmpty(viewModel.TextPreview))
				{
					await _squareService.AddSquareAsync(viewModel.Title, viewModel.TextPreview, viewModel.Content, path);

					return RedirectToAction("All");
				}
			}

			return View(viewModel);
		}

		[HttpGet]
		[Route("Delete")]
		[ActionName("Delete")]
		[Authorize(Policy = AccountPolicies.ElevatedRights, AuthenticationSchemes = "Identity.Application,Bearer")]
		public async Task<IActionResult> DeleteGetAsync(long id)
		{
			var square = await _squareService.GetSquareAsync(id);

			if (square is null)
			{
				return NotFound();
			}

			var squareVM = _mapper.Map<SquareViewModel>(square);

			return View(squareVM);
		}

		[HttpPost]
		[Route("Delete")]
		[ActionName("Delete")]
		[Authorize(Policy = AccountPolicies.ElevatedRights, AuthenticationSchemes = "Identity.Application,Bearer")]
		public async Task<IActionResult> DeleteAsync(long id)
		{
			await _squareService.DeleteSquareAsync(id);

			return RedirectToAction("All");
		}
	}
}
