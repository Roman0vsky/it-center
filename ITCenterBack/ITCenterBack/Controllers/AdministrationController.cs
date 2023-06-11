using AutoMapper;
using ITCenterBack.Constants;
using ITCenterBack.Interfaces;
using ITCenterBack.Services;
using ITCenterBack.ViewModels;
using ITCenterBack.ViewModels.AddViewModels;
using ITCenterBack.ViewModels.BasicViewModels;
using ITCenterBack.ViewModels.DetailsViewModels;
using Microsoft.AspNetCore.Authorization;
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
        private readonly ISectionService _sectionService;
        private readonly IWebHostEnvironment _appEnvironment;
		private readonly IMapper _mapper;

        public AdministrationController(ISocialLinkService linkService, IAdministrationService administrationService, 
			IInfoService infoService, ISectionService sectionService, IWebHostEnvironment appEnvironment, 
			IMapper mapper)
        {
            _linkService = linkService;
            _administrationService = administrationService;
            _infoService = infoService;
            _sectionService = sectionService;
            _appEnvironment = appEnvironment;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("Details")]
        [ActionName("Details")]
        public async Task<IActionResult> DetailsAsync()
        {
            var administration = await _administrationService.GetAllAdministrationAsync();
            var administrationVM = _mapper.Map<List<AdministrationViewModel>>(administration);

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

            var page = new AdministrationDetailsViewModel
            {
                Administration = administrationVM,
                Header = header,
                Footer = footer
            };

            return View(page);
        }

        [HttpGet]
		[Route("All")]
		[ActionName("All")]
		[Authorize(Policy = AccountPolicies.ElevatedRights, AuthenticationSchemes = "Identity.Application,Bearer")]
		public async Task<IActionResult> AllAsync()
		{
			var administration = await _administrationService.GetAllAdministrationAsync();
			var administrationVM = _mapper.Map<List<AdministrationViewModel>>(administration);

			return View(administrationVM);
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
		public async Task<IActionResult> PostAddAsync([FromForm] AddAdministrationViewModel viewModel, IFormFile uploadedFile)
		{
			if (uploadedFile != null)
			{
				string path = "/images/" + uploadedFile.FileName;

				using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
				{
					await uploadedFile.CopyToAsync(fileStream);
				}

				if (!string.IsNullOrEmpty(viewModel.Name) && !string.IsNullOrEmpty(viewModel.Description))
				{
					await _administrationService.CreateAdministrationAsync(viewModel.Name, viewModel.Description, path, viewModel.Link, viewModel.IsAdministrator, viewModel.IsHeadOfThecenter);

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
			var administration = await _administrationService.GetAdministrationAsync(id);

			if (administration is null)
			{
				return NotFound();
			}

			var administrationVM = _mapper.Map<AdministrationViewModel>(administration);

			return View(administrationVM);
		}

		[HttpPost]
		[Route("Delete")]
		[ActionName("Delete")]
		[Authorize(Policy = AccountPolicies.ElevatedRights, AuthenticationSchemes = "Identity.Application,Bearer")]
		public async Task<IActionResult> DeleteAsync(long id)
		{
			await _administrationService.DeleteAdministrationAsync(id);

			return RedirectToAction("All");
		}
	}
}
