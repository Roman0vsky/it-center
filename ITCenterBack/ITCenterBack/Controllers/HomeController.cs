using AutoMapper;
using ITCenterBack.Interfaces;
using ITCenterBack.Models;
using ITCenterBack.Utilities;
using ITCenterBack.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;

namespace ITCenterBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly IAccountService _accountService;
        private readonly ISchoolService _schoolService;
        private readonly INewsService _newsService;
		private readonly ISocialLinkService _linkService;
		private readonly IImagesService _imagesService;
        private readonly IApplicationService _applicationService;
		private readonly IMapper _mapper;
		private readonly IOptions<JwtConfigurationModel> _jwtConfig;

        public HomeController(ICourseService courseService, IAccountService accountService, ISchoolService schoolService, INewsService newsService, ISocialLinkService linkService, 
            IImagesService imagesService, IApplicationService applicationService, IMapper mapper, IOptions<JwtConfigurationModel> jwtConfig)
        {
            _courseService = courseService;
            _accountService = accountService;
            _schoolService = schoolService;
            _newsService = newsService;
            _linkService = linkService;
            _imagesService = imagesService;
            _applicationService = applicationService;
            _mapper = mapper;
            _jwtConfig = jwtConfig;
        }

        private async Task<HeaderViewModel> HeaderInfoAsync ()
        {
			var courses = await _courseService.GetAllCoursesAsync();
			var coursesVM = _mapper.Map<List<CourseViewModel>>(courses);

            var links = await _linkService.GetAllSocialLinksAsync();
            var linksVM = _mapper.Map<List<SocialLinkViewModel>>(links);

            var header = new HeaderViewModel
            {
                Courses = coursesVM,
                Links = linksVM
            };

            return header;
		}

		[Route("Index")]
        public async Task<IActionResult> IndexAsync(CourseType courseType = CourseType.All)
        {
            var courses = await _courseService.GetAllCoursesAsync();
            var coursesVM = _mapper.Map<List<CourseViewModel>>(courses);

            var sliderImages = await _imagesService.GetSliderImages();
            var sliderImagesVM = _mapper.Map<List<SliderImageViewModel>>(sliderImages);

			var header = await HeaderInfoAsync();

            var page = new IndexViewModel
            {
                Header = header,
                SliderImages = sliderImagesVM
			};

            switch(courseType)
            {
                case CourseType.Design:
                    coursesVM = coursesVM.Where(c => c.CourseType == CourseType.Design).ToList();
                    break;
                case CourseType.Development:
                    coursesVM = coursesVM.Where(c => c.CourseType == CourseType.Development).ToList();
                    break;
                case CourseType.Robotics:
                    coursesVM = coursesVM.Where(c => c.CourseType == CourseType.Robotics).ToList();
                    break;
                case CourseType.Other:
                    coursesVM = coursesVM.Where(c => c.CourseType == CourseType.Other).ToList();
                    break;
                case CourseType.All:
                    break;
            }

            var news = await _newsService.GetAllNewsAsync();
            var newsVM = _mapper.Map<List<NewsViewModel>>(news);

            newsVM = newsVM.OrderBy(n => n.PublicationDate).Take(3).ToList();

            page.Courses = coursesVM;
            page.News = newsVM;

            return View(page);
        }

        [HttpGet]
        [ActionName("Contacts")]
        [Route("Contacts")]
        public async Task<IActionResult> ContactsAsync()
        {
            var courses = await _courseService.GetAllCoursesAsync();
            var coursesVM = _mapper.Map<List<CourseViewModel>>(courses);

            var schools = await _schoolService.GetAllSchoolsAsync();
            var schoolsVM = _mapper.Map<List<SchoolViewModel>>(schools);

            var header = await HeaderInfoAsync();

            var page = new ContactsViewModel
            {
                Header = header,
				Schools = schoolsVM, /*new SelectList(schoolsVM, "Id", "Name"),*/
                Courses = coursesVM
            };

            return View(page);
        }

        [HttpPost]
        [ActionName("Contacts")]
        [Route("Contacts")]
        public async Task<IActionResult> PostContactsAsync()
        {
            string fio = Request.Form["contact_fio"];
            string schoolName = Request.Form["choose-school__select"];
            string schoolNameAlt = Request.Form["school-number"];
            var classNumber = int.Parse(Request.Form["class-number"]);
            string repPhone = Request.Form["rep-phone"];
            string repFio = Request.Form["rep-fio"];
            var coursesId = Request.Form["courses"].Select(long.Parse).ToList();
            

            if (string.IsNullOrWhiteSpace(schoolName))
            {
                await _applicationService.CreateApplication(schoolNameAlt, classNumber, fio, repFio, repPhone, null, coursesId);
                return RedirectToAction("Contacts");
            }

            await _applicationService.CreateApplication(schoolName, classNumber, fio, repFio, repPhone, null, coursesId);

            return RedirectToAction("Contacts");

            //string schoolName;

            //if(!string.IsNullOrWhiteSpace(viewModel.Schools.SelectedValue.ToString()))
            //{
            //    schoolName = viewModel.Schools.SelectedValue.ToString();
            //}
            //else
            //{
            //    schoolName = viewModel.SchoolName;
            //}


            //await _applicationService.CreateApplication(schoolName, viewModel.Class, viewModel.PhoneNumber, viewModel.ListenerFullName, viewModel.RepresentativeFullName,
            //    viewModel.RepresentativePhoneNumber, null, null);

            //return View(viewModel);
        }

        [HttpGet]
        [ActionName("Schedule")]
        [Route("Schedule")]
        public async Task<IActionResult> ScheduleAsync()
        {
            var header = await HeaderInfoAsync();

            var page = new ScheduleViewModel
            {
                Header = header
			};

            return View(page);
        }

        [HttpPost]
        [ActionName("Schedule")]
        public IActionResult PostScheduleAsync()
        {
            return View();
        }

        [HttpGet]
        [ActionName("Login")]
        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Login")]
		[Route("Login")]
		public async Task<IActionResult> PostLoginAsync([FromForm] LoginViewModel viewModel)
        {
            var userToken = await _accountService.LoginAsync(viewModel.UserName, viewModel.Password, _jwtConfig);
			HttpContext.Session.SetString("Token", userToken);

            return Redirect("/api/Admin/Schools");
		}
    }
}
