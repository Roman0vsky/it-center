using AutoMapper;
using ITCenterBack.Constants;
using ITCenterBack.Interfaces;
using ITCenterBack.Models;
using ITCenterBack.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Signing;
using System.IO;
using System.Net.WebSockets;

namespace ITCenterBack.Controllers
{
    [Authorize(Policy = AccountPolicies.ElevatedRights, AuthenticationSchemes = "Identity.Application,Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICourseService _courseService;
        private readonly ISchoolService _schoolService;
        private readonly INewsService _newsService;
        private readonly ITeacherService _teacherService;
		private readonly ISocialLinkService _linkService;
        private readonly IImagesService _imagesService;
        private readonly IWebHostEnvironment _appEnvironment;

        public AdminController(IMapper mapper, ICourseService courseService, ISchoolService schoolService, INewsService newsService, ITeacherService teacherService, 
			ISocialLinkService linkService, IImagesService imagesService, IWebHostEnvironment appEnvironment)
        {
            _mapper = mapper;
            _courseService = courseService;
            _schoolService = schoolService;
            _newsService = newsService;
            _teacherService = teacherService;
            _linkService = linkService;
            _imagesService = imagesService;
            _appEnvironment = appEnvironment;
        }

        [HttpGet]
		[Route("Teachers")]
		[ActionName("Teachers")]
		public async Task<IActionResult> TeachersAsync()
        {
			var teachers = await _teacherService.GetAllAsync();
			var teachersVM = _mapper.Map<List<TeacherViewModel>>(teachers);

			var courses = new List<Course>();

			foreach (var t in teachersVM)
			{
				courses = await _teacherService.GetCoursesAsync(t.Id);
				t.Courses = _mapper.Map<List<CourseViewModel>>(courses);
			}

			return View(teachersVM);
        }

		[HttpGet]
		[Route("Schools")]
		[ActionName("Schools")]
		public async Task<IActionResult> SchoolsAsync()
		{
			var schools = await _schoolService.GetAllSchoolsAsync();
			var schoolsVM = _mapper.Map<List<SchoolViewModel>>(schools);

			return View(schoolsVM);
		}

		[HttpGet]
		[Route("Courses")]
		[ActionName("Courses")]
		public async Task<IActionResult> CoursesAsync()
		{
			var courses = await _courseService.GetAllCoursesAsync();
			var coursesVM = _mapper.Map<List<CourseViewModel>>(courses);

			return View(coursesVM);
		}

		[HttpGet]
		[Route("News")]
		[ActionName("News")]
		public async Task<IActionResult> NewsAsync()
		{
			var news = await _newsService.GetAllNewsAsync();
			var newsVM = _mapper.Map<List<NewsViewModel>>(news);

			return View(newsVM);
		}

		[HttpGet]
		[Route("Links")]
		[ActionName("Links")]
		public async Task<IActionResult> LinksAsync()
		{
			var links = await _linkService.GetAllSocialLinksAsync();
			var linksVM = _mapper.Map<List<SocialLinkViewModel>>(links);

			return View(linksVM);
		}

		[HttpGet]
		[ActionName("AddLink")]
		[Route("AddLink")]
		public IActionResult AddLink()
		{
			return View();
		}

		[HttpPost]
		[ActionName("AddLink")]
		[Route("AddLink")]
		public async Task<IActionResult> PostAddLinkAsync([FromForm] AddSocialLinkViewModel viewModel)
		{
			if (!string.IsNullOrEmpty(viewModel.Name) && !string.IsNullOrWhiteSpace(viewModel.Url))
			{
				await _linkService.CreateSocialLinkAsync(viewModel.Name, viewModel.Url);

				return RedirectToAction("SocialLinks");
			}

			return View(viewModel);
		}

		[HttpGet]
		[ActionName("AddSchool")]
		[Route("AddSchool")]
		public IActionResult AddSchool()
		{
			return View();
		}

		[HttpPost]
		[ActionName("AddSchool")]
		[Route("AddSchool")]
		public async Task<IActionResult> PostAddSchoolAsync([FromForm] AddSchoolViewModel viewModel)
		{
			if(!string.IsNullOrEmpty(viewModel.Name))
			{
				await _schoolService.CreateSchoolAsync(viewModel.Name);

				return RedirectToAction("Schools");
			}

			return View(viewModel);
		}

		[HttpGet]
		[ActionName("UpdateSchool")]
		[Route("UpdateSchool")]
		public async Task<IActionResult> GetUpdateSchoolAsync(long id)
		{
			var school = await _schoolService.GetSchoolAsync(id);

			if (school is null)
			{
				return NotFound();
			}

			var schoolVM = _mapper.Map<SchoolViewModel>(school);

			return View(schoolVM);
		}

		[HttpPost]
		[Route("UpdateSchool")]
		[ActionName("UpdateSchool")]
		public async Task<IActionResult> UpdateSchoolAsync([FromForm] SchoolViewModel viewModel)
		{
			var school = await _schoolService.GetSchoolAsync(viewModel.Id);

			if (school is null)
			{
				return NotFound();
			}

			await _schoolService.UpdateSchoolAsync(viewModel.Id, viewModel.Name);

			return RedirectToAction("Schools");
		}

		[HttpGet]
		[Route("DeleteSchool")]
		[ActionName("DeleteSchool")]
		public async Task<IActionResult> DeleteSchoolGetAsync(long id)
		{
			var school = await _schoolService.GetSchoolAsync(id);

			if (school is null)
			{
				return NotFound();
			}

			var schoolVM = _mapper.Map<SchoolViewModel>(school);

			return View(schoolVM);
		}

		[HttpPost]
		[Route("DeleteSchool")]
		[ActionName("DeleteSchool")]
		public async Task<IActionResult> DeleteSchoolAsync(long id)
		{
			await _schoolService.DeleteSchoolAsync(id);

			return RedirectToAction("Schools");
		}

		[HttpGet]
		[ActionName("AddTeacher")]
		[Route("AddTeacher")]
		public async Task<IActionResult> GetAddTeacherAsync()
		{
			var courses = await _courseService.GetAllCoursesAsync();
			var coursesVM = _mapper.Map<List<CourseViewModel>>(courses);

			var page = new AddTeacherViewModel
			{
				Courses = coursesVM
			};

			return View(page);
		}

		[HttpPost]
		[ActionName("AddTeacher")]
		[Route("AddTeacher")]
		public async Task<IActionResult> PostAddTeacherAsync([FromForm] AddTeacherViewModel viewModel, IFormFile uploadedFile)
		{
            if (uploadedFile != null)
            {
                // путь к папке images
                string path = "/images/" + uploadedFile.FileName;
                // сохраняем файл в папку в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }

				var coursesId = Request.Form["courses"]/*.Select(long.Parse).ToList()*/;

				if (!string.IsNullOrWhiteSpace(coursesId))
				{
					var ids = coursesId.Select(long.Parse).ToList();

					await _teacherService.CreateTeacherAsync(viewModel.Name, viewModel.Link, path, ids);
				}
				else
				{
					await _teacherService.CreateTeacherAsync(viewModel.Name, viewModel.Link, path);
				}

				return RedirectToAction("Teachers");
			}

			return View(viewModel);
		}

		[HttpGet]
		[Route("DeleteTeacher")]
		[ActionName("DeleteTeacher")]
		public async Task<IActionResult> DeleteTeacherGetAsync(long id)
		{
			var teacher = await _teacherService.GetTeacher(id);

			if (teacher is null)
			{
				return NotFound();
            }

			var teacherVM = _mapper.Map<TeacherViewModel>(teacher);

            return View(teacherVM);
		}

		[HttpPost]
		[Route("DeleteTeacher")]
		[ActionName("DeleteTeacher")]
		public async Task<IActionResult> DeleteTeacher(long id)
		{
			await _teacherService.DeleteTeacherAsync(id);

			return RedirectToAction("Teachers");
		}

		[HttpGet]
		[ActionName("AddCourse")]
		[Route("AddCourse")]
		public IActionResult AddCourse()
		{
			return View();
		}

		[HttpPost]
		[ActionName("AddCourse")]
		[Route("AddCourse")]
		public async Task<IActionResult> PostAddCourseAsync([FromForm] AddCourseViewModel viewModel, IFormFile uploadedFile)
		{
            if (uploadedFile != null)
			{
                string path = "/images/" + uploadedFile.FileName;
                
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }

                if (!string.IsNullOrEmpty(viewModel.Name))
                {
                    await _courseService.CreateCourseAsync(viewModel.Name, viewModel.Age, viewModel.Requirements, viewModel.Description, viewModel.CourseType, path);

                    return RedirectToAction("Courses");
                }
            }
               
			return View(viewModel);
		}

		[HttpGet]
		[Route("DeleteCourse")]
		[ActionName("DeleteCourse")]
		public async Task<IActionResult> DeleteCourseGetAsync(long id)
		{
			var course = await _courseService.GetCourseAsync(id);

			if (course is null)
			{
				return NotFound();
			}

			var courseVM = _mapper.Map<CourseViewModel>(course);

			return View(courseVM);
		}

		[HttpPost]
		[Route("DeleteCourse")]
		[ActionName("DeleteCourse")]
		public async Task<IActionResult> DeleteCourseAsync(long id)
		{
			await _courseService.DeleteCourseAsync(id);

			return RedirectToAction("Courses");
		}

		[HttpGet]
		[ActionName("AddNews")]
		[Route("AddNews")]
		public IActionResult AddNews()
		{
			return View();
		}

		[HttpPost]
		[ActionName("AddNews")]
		[Route("AddNews")]
		public async Task<IActionResult> PostAddNewsAsync([FromForm] AddNewsViewModel viewModel, IFormFile uploadedImage/*, List<IFormFile> uploadedFiles*/)
		{
			if (uploadedImage != null)
			{
				string path = "/images/" + uploadedImage.FileName;

				using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
				{
					await uploadedImage.CopyToAsync(fileStream);
				}

				//List<string> files = new List<string>();

				//foreach (var file in uploadedFiles)
				//{
				//	string file = 
				//}


				if (!string.IsNullOrEmpty(viewModel.Title))
				{
					await _newsService.CreateNewsAsync(viewModel.Title, viewModel.ShortText, viewModel.Text, path);

					return RedirectToAction("News");
				}
			}

			return View(viewModel);
		}

		[HttpGet]
		[Route("DeleteNews")]
		[ActionName("DeleteNews")]
		public async Task<IActionResult> DeleteNewsGetAsync(long id)
		{
			var news = await _newsService.GetNewsAsync(id);

			if (news is null)
			{
				return NotFound();
			}

			var newsVM = _mapper.Map<NewsViewModel>(news);

			return View(newsVM);
		}

		[HttpPost]
		[Route("DeleteNews")]
		[ActionName("DeleteNews")]
		public async Task<IActionResult> DeleteNewsAsync(long id)
		{
			await _newsService.DeleteNewsAsync(id);

			return RedirectToAction("News");
		}


		//Slider images
		[HttpGet]
        [Route("SliderImages")]
        [ActionName("SliderImages")]
        public async Task<IActionResult> SliderImagesAsync()
		{
			var images = await _imagesService.GetSliderImagesAsync();
			var imagesVM = _mapper.Map<List<SliderImageViewModel>>(images);

			return View(imagesVM);
        }

		[HttpGet]
		[ActionName("AddSliderImage")]
		[Route("AddSliderImage")]
		public IActionResult AddSliderImage()
		{
			return View();
		}

		[HttpPost]
		[ActionName("AddSliderImage")]
		[Route("AddSliderImage")]
		public async Task<IActionResult> PostAddSliderImageAsync(IFormFile uploadedFile)
		{
			if (uploadedFile != null)
			{
				string path = "/images/" + uploadedFile.FileName;

				using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
				{
					await uploadedFile.CopyToAsync(fileStream);
				}

				await _imagesService.AddSliderImageAsync(path);

				return RedirectToAction("SliderImages");
			}

			return View();
		}

		[HttpGet]
		[Route("DeleteSliderImage")]
		[ActionName("DeleteSliderImage")]
		public async Task<IActionResult> DeleteSliderImageGetAsync(long id)
		{
			var sliderImage = await _imagesService.GetSliderImageAsync(id);

			if (sliderImage is null)
			{
				return NotFound();
			}

			var sliderVM = _mapper.Map<SliderImageViewModel>(sliderImage);

			return View(sliderVM);
		}

		[HttpPost]
		[Route("DeleteSliderImage")]
		[ActionName("DeleteSliderImage")]
		public async Task<IActionResult> DeleteSliderImageAsync(long id)
		{
			await _imagesService.DeleteSliderImageAsync(id);

			return RedirectToAction("SliderImages");
		}

		//Social links
		[HttpGet]
		[Route("SocialLinks")]
		[ActionName("SocialLinks")]
		public async Task<IActionResult> SocialLinksAsync()
		{
			var link = await _linkService.GetAllSocialLinksAsync();
			var linkVM = _mapper.Map<List<SocialLinkViewModel>>(link);

			return View(linkVM);
		}

		[HttpGet]
		[ActionName("AddSocialLinks")]
		[Route("AddSocialLinks")]
		public IActionResult AddSocialLinks()
		{
			return View();
		}

		[HttpPost]
		[ActionName("AddSocialLink")]
		[Route("AddSocialLink")]
		public async Task<IActionResult> PostAddSocialLinkAsync([FromForm] AddSocialLinkViewModel viewModel)
		{
			if (!string.IsNullOrWhiteSpace(viewModel.Name) && !string.IsNullOrWhiteSpace(viewModel.Url))
			{
				await _linkService.CreateSocialLinkAsync(viewModel.Name, viewModel.Url);

				return RedirectToAction("SocialLinks");
			}

			return View(viewModel);
		}

		[HttpGet]
		[Route("DeleteSocialLink")]
		[ActionName("DeleteSocialLink")]
		public async Task<IActionResult> DeleteSocialLinkGetAsync(long id)
		{
			var link = await _linkService.GetSocialLinkAsync(id);

			if (link is null)
			{
				return NotFound();
			}

			var linkVM = _mapper.Map<SocialLinkViewModel>(link);

			return View(linkVM);
		}

		[HttpPost]
		[Route("DeleteSocialLink")]
		[ActionName("DeleteSocialLink")]
		public async Task<IActionResult> DeleteSocialLinkAsync(long id)
		{
			await _linkService.DeleteSocialLinkAsync(id);

			return RedirectToAction("SocialLinks");
		}

        [HttpGet]
        [ActionName("UpdateSocialLink")]
        [Route("UpdateSocialLink")]
        public async Task<IActionResult> GetUpdateSocialLinkAsync(long id)
        {
			var link = await _linkService.GetSocialLinkAsync(id);

            if (link is null)
            {
                return NotFound();
            }

            var linkVM = _mapper.Map<SocialLinkViewModel>(link);

            return View(linkVM);
        }

        [HttpPost]
        [Route("UpdateSocialLink")]
        [ActionName("UpdateSocialLink")]
        public async Task<IActionResult> UpdateSocialLinkAsync([FromForm] SocialLinkViewModel viewModel)
        {
            var link = await _linkService.GetSocialLinkAsync(viewModel.Id);

            if (link is null)
            {
                return NotFound();
            }

			await _linkService.UpdateSocialLinkAsync(viewModel.Id, viewModel.Name, viewModel.Url);

            return RedirectToAction("SocialLinks");
        }


        //schedule UpdateScheduleDescription

        [HttpGet]
		[Route("UpdateSchedule")]
		[ActionName("UpdateSchedule")]
		public async Task<IActionResult> UpdateScheduleAsync()
		{
			var schedule = await _imagesService.GetScheduleAsync();
			var scheduleVM = _mapper.Map<ScheduleViewModel>(schedule);

			return View(scheduleVM);
		}

		[HttpGet]
		[ActionName("UpdateScheduleDescription")]
		[Route("UpdateScheduleDescription")]
		public IActionResult GetUpdateScheduleDescription()
		{
			return View();
		}

		[HttpPost]
		[Route("UpdateScheduleDescription")]
		[ActionName("UpdateScheduleDescription")]
		public async Task<IActionResult> UpdateScheduleDescriptionAsync([FromForm] UpdateScheduleDescription viewModel)
		{
			if(!string.IsNullOrWhiteSpace(viewModel.Description))
			{
				await _imagesService.UpdateScheduleDescriptionAsync(viewModel.Description);
			}			

			return RedirectToAction("UpdateSchedule");
		}

		[HttpGet]
		[ActionName("UpdateScheduleImage")]
		[Route("UpdateScheduleImage")]
		public async Task<IActionResult> GetUpdateScheduleImageAsync()
		{
			var schedule = await _imagesService.GetScheduleAsync();

			var scheduleVM = _mapper.Map<ScheduleViewModel>(schedule);

			return View(scheduleVM);
		}

		[HttpPost]
		[Route("UpdateScheduleImage")]
		[ActionName("UpdateScheduleImage")]
		public async Task<IActionResult> UpdateScheduleImageAsync(IFormFile uploadedFile)
		{
			if (uploadedFile != null)
			{
				// путь к папке images/schedule
				string path = "/images/schedule" + uploadedFile.FileName;
				// сохраняем файл в папку в каталоге wwwroot
				using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
				{
					await uploadedFile.CopyToAsync(fileStream);
				}

				await _imagesService.UpdateScheduleImageAsync(path);
			}

			return RedirectToAction("UpdateSchedule");
		}
	}
}
