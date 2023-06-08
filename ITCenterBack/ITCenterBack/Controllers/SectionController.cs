using AutoMapper;
using ITCenterBack.Constants;
using ITCenterBack.Interfaces;
using ITCenterBack.Services;
using ITCenterBack.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITCenterBack.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
    public class SectionController : Controller
    {
        private readonly ISocialLinkService _linkService;
        private readonly ISectionService _sectionService;
        private readonly IInfoService _infoService;
		private readonly IWebHostEnvironment _appEnvironment;
		private readonly IMapper _mapper;

		public SectionController(ISocialLinkService linkService, ISectionService sectionService, IInfoService infoService, 
			IWebHostEnvironment appEnvironment, IMapper mapper)
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
            var section = await _sectionService.GetSectionAsync(id);

            if (section is not null)
            {
                var sectionVM = _mapper.Map<SectionViewModel>(section);

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

                var page = new SectionDetailsViewModel
                {
                    Section = sectionVM,
                    Header = header,
                    Footer = footer
                };

                return View(page);
            }

            return NotFound();
        }

		[HttpGet]
		[Route("All")]
		[ActionName("All")]
		[Authorize(Policy = AccountPolicies.ElevatedRights, AuthenticationSchemes = "Identity.Application,Bearer")]
		public async Task<IActionResult> AllAsync()
		{
			var sections = await _sectionService.GetAllSections();
			var sectionsVM = _mapper.Map<List<SectionViewModel>>(sections);

			return View(sectionsVM);
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
		public async Task<IActionResult> PostAddAsync([FromForm] AddSectionViewModel viewModel, IFormFile uploadedFile)
		{
			if (uploadedFile != null)
			{
				string path = "/images/sections/" + uploadedFile.FileName;

				using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
				{
					await uploadedFile.CopyToAsync(fileStream);
				}

				if (!string.IsNullOrEmpty(viewModel.Name))
				{
					await _sectionService.CreateSectionAsync(viewModel.Name, viewModel.Description, path);

					return RedirectToAction("All");
				}
			}

			return View(viewModel);
		}

		[HttpGet]
		[Route("Delete")]
		[ActionName("Delete")]
		[Authorize(Policy = AccountPolicies.ElevatedRights, AuthenticationSchemes = "Identity.Application,Bearer")]
		public async Task<IActionResult> DeleteCourseGetAsync(long id)
		{
			var section = await _sectionService.GetSectionAsync(id);

			if (section is null)
			{
				return NotFound();
			}

			var sectionVM = _mapper.Map<SectionViewModel>(section);

			return View(sectionVM);
		}

		[HttpPost]
		[Route("Delete")]
		[ActionName("Delete")]
		[Authorize(Policy = AccountPolicies.ElevatedRights, AuthenticationSchemes = "Identity.Application,Bearer")]
		public async Task<IActionResult> DeleteCourseAsync(long id)
		{
			await _sectionService.DeleteSectionAsync(id);

			return RedirectToAction("All");
		}
	}
}
