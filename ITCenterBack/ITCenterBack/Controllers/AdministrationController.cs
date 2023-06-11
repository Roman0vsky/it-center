using AutoMapper;
using ITCenterBack.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ITCenterBack.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AdministrationController : Controller
	{
		private readonly ISocialLinkService _linkService;
		private readonly IAdministrationService _administrationService;
		private readonly IInfoService _infoService;
		private readonly IWebHostEnvironment _appEnvironment;
		private readonly IMapper _mapper;

		public AdministrationController(ISocialLinkService linkService, IAdministrationService administrationService, IInfoService infoService, 
			IWebHostEnvironment appEnvironment, IMapper mapper)
		{
			_linkService = linkService;
			_administrationService = administrationService;
			_infoService = infoService;
			_appEnvironment = appEnvironment;
			_mapper = mapper;
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
