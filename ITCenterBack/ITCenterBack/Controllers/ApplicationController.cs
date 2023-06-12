using AutoMapper;
using ITCenterBack.Constants;
using ITCenterBack.Interfaces;
using ITCenterBack.Models;
using ITCenterBack.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ITCenterBack.Controllers
{
    [Authorize(Policy = AccountPolicies.ElevatedRights, AuthenticationSchemes = "Identity.Application,Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : Controller
    {
		private readonly IApplicationService _applicationService;
		private readonly ICourseService _courseService;
		private readonly IMapper _mapper;

		public ApplicationController(IApplicationService applicationService, ICourseService courseService, IMapper mapper)
		{
			_applicationService = applicationService;
			_courseService = courseService;
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
		public async Task<IActionResult> ApplicationsAsync(string? fullName, string? school, string? clas, string? phone, string? representativeFullName, long? course)
		{
			var applications = await _applicationService.GetAll();

			if (!string.IsNullOrEmpty(fullName))
			{
				applications = applications.Where(p => p.ListenerFullName.ToLower().Contains(fullName.ToLower())).ToList();
			}

			if (!string.IsNullOrEmpty(school))
			{
				applications = applications.Where(p => p.SchoolName.ToLower().Contains(school.ToLower())).ToList();
			}

			if (!string.IsNullOrEmpty(clas))
			{
				applications = applications.Where(p => p.Class.ToString().Contains(clas.ToLower())).ToList();
			}

			if (!string.IsNullOrEmpty(phone))
			{
				applications = applications.Where(p => p.RepresentativePhoneNumber.ToLower().Contains(phone.ToLower())).ToList();
			}

			if (!string.IsNullOrEmpty(representativeFullName))
			{
				applications = applications.Where(p => p.RepresentativeFullName.ToLower().Contains(representativeFullName.ToLower())).ToList();
			}

			var applicationsVM = _mapper.Map<List<ApplicationViewModel>>(applications);
			var courses = new ApplicationDetailsViewModel();

			foreach (var appl in applicationsVM)
			{
				courses = await _applicationService.GetApplication(appl.Id);

				appl.Courses = courses.Courses;
			}

			if(course > 0 && course != null)
			{
				var cours = await _courseService.GetCourseAsync(course.Value);

				applicationsVM = applicationsVM.Where(p => p.Courses.Contains(cours.Name)).ToList();
			}

			var allCourses = await _courseService.GetAllCoursesAsync();

			var applsVM = new ApplicationsViewModel
			{
				Applications = applicationsVM,
				Courses = new SelectList(allCourses, "Id", "Name")
			};

			return View(applsVM);
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
