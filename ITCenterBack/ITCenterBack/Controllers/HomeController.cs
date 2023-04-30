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

        //to do
        //public Task<IActionResult> ContactsAsync()
        //{

        //}

        //public Task<IActionResult> SchelduleAsync()
        //{

        //}
    }
}
