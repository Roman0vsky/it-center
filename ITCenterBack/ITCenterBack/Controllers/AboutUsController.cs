using AutoMapper;
using ITCenterBack.Constants;
using ITCenterBack.Interfaces;
using ITCenterBack.ViewModels;
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

		[HttpGet]
		[ActionName("About")]
		public IActionResult About()
		{
			return View();
		}

		[HttpPost]
		[ActionName("About")]
		public async Task<ActionResult> PostAboutAsync()
		{
			var about = await _aboutUsService.GetAboutUs();
			var aboutVM = _mapper.Map<AboutUsViewModel>(about);

			return View(aboutVM);
		} 
	}
}
