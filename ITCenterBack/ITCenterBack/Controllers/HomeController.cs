using AutoMapper;
using ITCenterBack.Interfaces;
using ITCenterBack.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ITCenterBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;

        public HomeController(ICourseService courseService, IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
        }

        [Route("Index")]
        public async Task<IActionResult> IndexAsync()
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

            return View(page);
        }

        [HttpGet]
        [ActionName("Contacts")]
        [Route("Contacts")]
        public async Task<IActionResult> ContactsAsync()
        {
            var courses = await _courseService.GetAllCoursesAsync();
            var coursesVM = _mapper.Map<List<CourseViewModel>>(courses);

            var page = new ContactsViewModel
            {
                Header = new HeaderViewModel
                {
                    Courses = coursesVM
                }
            };

            return View(page);
        }

        [HttpPost]
        [ActionName("Contacts")]
        public IActionResult PostContactsAsync()
        {
            return View();
        }

        [HttpGet]
        [ActionName("Scheldule")]
        [Route("Scheldule")]
        public async Task<IActionResult> SchelduleAsync()
        {
            var courses = await _courseService.GetAllCoursesAsync();
            var coursesVM = _mapper.Map<List<CourseViewModel>>(courses);

            var page = new SchelduleViewModel
            {
                Header = new HeaderViewModel
                {
                    Courses = coursesVM
                }
            };

            return View(page);
        }

        [HttpPost]
        [ActionName("Scheldule")]
        public IActionResult PostSchelduleAsync()
        {
            return View();
        }

        [HttpGet]
        [ActionName("Login")]
        [Route("Scheldule")]
        public async Task<IActionResult> LoginAsync()
        {
            var courses = await _courseService.GetAllCoursesAsync();
            var coursesVM = _mapper.Map<List<CourseViewModel>>(courses);

            var page = new SchelduleViewModel
            {
                Header = new HeaderViewModel
                {
                    Courses = coursesVM
                }
            };

            return View(page);
        }

        [HttpPost]
        [ActionName("Login")]
        public IActionResult PostLoginAsync()
        {
            return View();
        }
    }
}
