using AutoMapper;
using ITCenterBack.Constants;
using ITCenterBack.Interfaces;
using ITCenterBack.Services;
using ITCenterBack.ViewModels;
using ITCenterBack.ViewModels.UpdateViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITCenterBack.Controllers
{
	[Authorize(Policy = AccountPolicies.ElevatedRights, AuthenticationSchemes = "Identity.Application,Bearer")]
	[Route("api/[controller]")]
	[ApiController]
	public class AboutUsController : Controller
	{
		private readonly IMapper _mapper;
		private readonly IAboutUsService _aboutUsService;

		public AboutUsController(IMapper mapper, IAboutUsService aboutUsService)
		{
			_mapper = mapper;
			_aboutUsService = aboutUsService;
		}

		//[HttpGet]
  //      [Route("About")]
  //      [ActionName("About")]
		//public IActionResult About()
		//{
		//	return View();
		//}

		[HttpGet]
        [Route("About")]
        [ActionName("About")]
		public async Task<IActionResult> AboutAsync()
		{
			var about = await _aboutUsService.GetAboutUs();
			var aboutVM = _mapper.Map<AboutUsViewModel>(about);

			return View(aboutVM);
		}

        [HttpGet]
        [ActionName("UpdateUrl")]
        [Route("UpdateUrl")]
        public IActionResult GetUpdateUrl()
        {
			return View();
		}

        [HttpPost]
        [Route("UpdateUrl")]
        [ActionName("UpdateUrl")]
        public async Task<IActionResult> UpdateUrlAsync([FromForm] UpdateAboutUsUrlViewModel viewModel)
        {
			if(!string.IsNullOrWhiteSpace(viewModel.Url))
			{
				await _aboutUsService.UpdateUrlAsync(viewModel.Url);
			}

            return RedirectToAction("About");
        }

		[HttpGet]
		[ActionName("UpdateDescription")]
		[Route("UpdateDescription")]
		public IActionResult GetUpdateDescription()
		{
			return View();
		}

		[HttpPost]
		[Route("UpdateDescription")]
		[ActionName("UpdateDescription")]
		public async Task<IActionResult> UpdateDescriptionAsync([FromForm] UpdateAboutUsDescriptionViewModel viewModel)
		{
			if (!string.IsNullOrWhiteSpace(viewModel.Description))
			{
				await _aboutUsService.UpdateDescriptionAsync(viewModel.Description);
			}

			return RedirectToAction("About");
		}
	}
}
