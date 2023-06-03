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
	public class InfoController : Controller
	{
		private readonly IMapper _mapper;
		private readonly IInfoService _infoService;
		private readonly IWebHostEnvironment _appEnvironment;

		public InfoController(IMapper mapper, IInfoService infoService, IWebHostEnvironment appEnvironment)
		{
			_mapper = mapper;
			_infoService = infoService;
			_appEnvironment = appEnvironment;
		}

		[HttpGet]
		[Route("Info")]
		[ActionName("Info")]
		public async Task<IActionResult> InfoAsync()
		{
			var info = await _infoService.GetInfoAsync();
			var infoVM = _mapper.Map<InfoViewModel>(info);

			return View(infoVM);
		}

		[HttpGet]
		[Route("UpdateSliderBigText")]
		[ActionName("UpdateSliderBigText")]
		public IActionResult UpdateSliderBigText()
		{
			return View();
		}

		[HttpPost]
		[Route("UpdateSliderBigText")]
		[ActionName("UpdateSliderBigText")]
		public async Task<IActionResult> UpdateSliderBigTextAsync([FromForm] UpdateAboutUsDescriptionViewModel viewModel)
		{
			if (!string.IsNullOrWhiteSpace(viewModel.Description))
			{
				await _infoService.UpdateSliderBigTextAsync(viewModel.Description);
			}

			return RedirectToAction("Info");
		}

		[HttpGet]
		[Route("UpdateSliderSmallText")]
		[ActionName("UpdateSliderSmallText")]
		public IActionResult UpdateSliderSmallText()
		{
			return View();
		}

		[HttpPost]
		[Route("UpdateSliderSmallText")]
		[ActionName("UpdateSliderSmallText")]
		public async Task<IActionResult> UpdateSliderSmallTextAsync([FromForm] UpdateAboutUsDescriptionViewModel viewModel)
		{
			if (!string.IsNullOrWhiteSpace(viewModel.Description))
			{
				await _infoService.UpdateSliderSmallTextAsync(viewModel.Description);
			}

			return RedirectToAction("Info");
		}

		[HttpGet]
		[Route("UpdateNameOfTheCenter")]
		[ActionName("UpdateNameOfTheCenter")]
		public IActionResult UpdateNameOfTheCenter()
		{
			return View();
		}

		[HttpPost]
		[Route("UpdateNameOfTheCenter")]
		[ActionName("UpdateNameOfTheCenter")]
		public async Task<IActionResult> UpdateNameOfTheCenterAsync([FromForm] UpdateAboutUsDescriptionViewModel viewModel)
		{
			if (!string.IsNullOrWhiteSpace(viewModel.Description))
			{
				await _infoService.UpdateNameOfTheCenterAsync(viewModel.Description);
			}

			return RedirectToAction("Info");
		}

		[HttpGet]
		[Route("UpdateHeaderLogo")]
		[ActionName("UpdateHeaderLogo")]
		public IActionResult UpdateHeaderLogo()
		{
			return View();
		}

		[HttpPost]
		[Route("UpdateHeaderLogo")]
		[ActionName("UpdateHeaderLogo")]
		public async Task<IActionResult> UpdateHeaderLogoAsync(IFormFile uploadedFile)
		{
			if (uploadedFile != null)
			{
				string path = "/images/logos" + uploadedFile.FileName;

				using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
				{
					await uploadedFile.CopyToAsync(fileStream);
				}

				await _infoService.UpdateHeaderLogoAsync(path);
			}

			return RedirectToAction("Info");
		}

		[HttpGet]
		[Route("UpdateFooterLogo")]
		[ActionName("UpdateFooterLogo")]
		public IActionResult UpdateFooterLogo()
		{
			return View();
		}

		[HttpPost]
		[Route("UpdateFooterLogo")]
		[ActionName("UpdateFooterLogo")]
		public async Task<IActionResult> UpdateFooterLogoAsync(IFormFile uploadedFile)
		{
			if (uploadedFile != null)
			{
				string path = "/images/logos" + uploadedFile.FileName;

				using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
				{
					await uploadedFile.CopyToAsync(fileStream);
				}

				await _infoService.UpdateFooterLogoAsync(path);
			}

			return RedirectToAction("Info");
		}

		[HttpGet]
		[Route("UpdateNameOfUniversity")]
		[ActionName("UpdateNameOfUniversity")]
		public IActionResult UpdateNameOfUniversity()
		{
			return View();
		}

		[HttpPost]
		[Route("UpdateNameOfUniversity")]
		[ActionName("UpdateNameOfUniversity")]
		public async Task<IActionResult> UpdateNameOfUniversityAsync([FromForm] UpdateAboutUsDescriptionViewModel viewModel)
		{
			if (!string.IsNullOrWhiteSpace(viewModel.Description))
			{
				await _infoService.UpdateNameOfUniversityAsync(viewModel.Description);
			}

			return RedirectToAction("Info");
		}

		[HttpGet]
		[Route("UpdateAdressOfUniversity")]
		[ActionName("UpdateAdressOfUniversity")]
		public IActionResult UpdateAdressOfUniversity()
		{
			return View();
		}

		[HttpPost]
		[Route("UpdateAdressOfUniversity")]
		[ActionName("UpdateAdressOfUniversity")]
		public async Task<IActionResult> UpdateAdressOfUniversityAsync([FromForm] UpdateAboutUsDescriptionViewModel viewModel)
		{
			if (!string.IsNullOrWhiteSpace(viewModel.Description))
			{
				await _infoService.UpdateAdressOfUniversityAsync(viewModel.Description);
			}

			return RedirectToAction("Info");
		}
	}
}
