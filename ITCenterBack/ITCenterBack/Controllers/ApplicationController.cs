﻿using AutoMapper;
using ITCenterBack.Constants;
using ITCenterBack.Interfaces;
using ITCenterBack.Models;
using ITCenterBack.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITCenterBack.Controllers
{
    [Authorize(Policy = AccountPolicies.ElevatedRights, AuthenticationSchemes = "Identity.Application,Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : Controller
    {
		private readonly IApplicationService _applicationService;
		private readonly IMapper _mapper;

		public ApplicationController(IApplicationService applicationService, IMapper mapper)
		{
			_applicationService = applicationService;
			_mapper = mapper;
		}

		[Route("Details/{id}")]
		[ActionName("Details")]
		public async Task<IActionResult> DetailsAsync(long id)
		{
			var application = await _applicationService.GetApplication(id);

			if(application is not null)
			{
				return View(application);
			}

			return NotFound();
		}

		[HttpGet]
		[Route("Applications")]
		[ActionName("Applications")]
		public async Task<IActionResult> ApplicationsAsync()
		{
			var applications = await _applicationService.GetAll();
			var applicationsVM = _mapper.Map<List<ApplicationViewModel>>(applications);

			return View(applicationsVM);
		}

		[HttpGet]
		[Route("Delete/{id}")]
		[ActionName("Delete")]
		public async Task<IActionResult> DeleteAsync(long id)
		{
			var application = await _applicationService.GetApplication(id);

			if (application is not null)
			{
				return View(application);
			}

			return NotFound();
		}

		[HttpPost]
		[Route("Delete/{id}")]
		[ActionName("Delete")]
		public async Task<IActionResult> PostDeleteAsync(long id)
		{
			await _applicationService.DeleteApplication(id);

			return RedirectToAction("Applications");
		}

		//[HttpGet]
		//[ActionName("UpdateApplication")]
		//[Route("UpdateApplication")]
		//public async Task<IActionResult> GetUpdateApplicationAsync(long id)
		//{
		//	var application = await _applicationService.GetApplication(id);

		//	if (application is null)
		//	{
		//		return NotFound();
		//	}

		//	return View(application);
		//}

		//[HttpPost]
		//[Route("UpdateApplication")]
		//[ActionName("UpdateApplication")]
		//public async Task<IActionResult> UpdateApplicationAsync([FromForm] ApplicationDetailsViewModel viewModel)
		//{


		//	return RedirectToAction("Applications");
		//}
	}
}
