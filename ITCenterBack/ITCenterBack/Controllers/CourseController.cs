using AutoMapper;
using ITCenterBack.Constants;
using ITCenterBack.Interfaces;
using ITCenterBack.Models;
using ITCenterBack.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITCenterBack.Controllers
{
    //[Authorize(Policy = AccountPolicies.ElevatedRights)]
    //[AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;

        public CourseController(ICourseService courseService, IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
        }

        //[HttpGet]
        [Route("Details/{id}")]
        //[ActionName("Details")]
        public async Task<IActionResult> DetailsAsync(long id)
        {
            var course = await _courseService.GetCourseAsync(id);
            if (course is not null)
            {
                var courseVM = _mapper.Map<CourseViewModel>(course);
                return View(courseVM);
            }

            return NotFound();
        }

        public async Task<IActionResult> AllCoursesAsync()
        {
            var courses = await _courseService.GetAllCoursesAsync();
            var coursesVM = _mapper.Map<List<CourseViewModel>>(courses);

            return View();
        }

        //public async Task<IActionResult> _HeaderAsync()
        //{
        //    var courses = await _courseService.GetAllCoursesAsync();
        //    var coursesVM = _mapper.Map<List<CourseViewModel>>(courses);

        //    ViewBag.Courses = coursesVM;

        //    return View();
        //}
    }
}
