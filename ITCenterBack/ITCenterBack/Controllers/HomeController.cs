using AutoMapper;
using ITCenterBack.Interfaces;
using ITCenterBack.Models;
using ITCenterBack.Utilities;
using ITCenterBack.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IMapper _mapper;
		private readonly IOptions<JwtConfigurationModel> _jwtConfig;

        public HomeController(ICourseService courseService, IAccountService accountService, ISchoolService schoolService, 
            INewsService newsService, IMapper mapper, IOptions<JwtConfigurationModel> jwtConfig)
        {
            _courseService = courseService;
            _accountService = accountService;
            _schoolService = schoolService;
            _newsService = newsService;
            _mapper = mapper;
            _jwtConfig = jwtConfig;
        }

        [Route("Index")]
        public async Task<IActionResult> IndexAsync(CourseType courseType = CourseType.All)
        {
            var courses = await _courseService.GetAllCoursesAsync();
            var coursesVM = _mapper.Map<List<CourseViewModel>>(courses);

            var page = new IndexViewModel
            {
                Header = new HeaderViewModel
                {
                    Courses = coursesVM
                }
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

            var page = new ContactsViewModel
            {
                Header = new HeaderViewModel
                {
                    Courses = coursesVM
                },
                Schools = schoolsVM,
                Courses = coursesVM
            };

            return View(page);
        }

        [HttpPost]
        [ActionName("Contacts")]
        public async Task<IActionResult> PostContactsAsync([FromForm] ContactsViewModel viewModel)
        {
            return View(viewModel);
        }

        [HttpGet]
        [ActionName("Schedule")]
        [Route("Schedule")]
        public async Task<IActionResult> ScheduleAsync()
        {
            var courses = await _courseService.GetAllCoursesAsync();
            var coursesVM = _mapper.Map<List<CourseViewModel>>(courses);

            var page = new ScheduleViewModel
            {
                Header = new HeaderViewModel
                {
                    Courses = coursesVM
                }
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
