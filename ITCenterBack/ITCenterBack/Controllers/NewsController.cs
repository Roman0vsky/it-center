using AutoMapper;
using ITCenterBack.Interfaces;
using ITCenterBack.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ITCenterBack.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NewsController : Controller
	{
		private readonly IMapper _mapper;
		private readonly ICourseService _courseService;
		//private readonly ISchoolService _schoolService;
		//private readonly ITeacherService _teacherService;
		private readonly INewsService _newsService;

		public NewsController(IMapper mapper, ICourseService courseService, INewsService newsService)
		{
			_mapper = mapper;
			_courseService = courseService;
			_newsService = newsService;
		}

		[Route("Details/{id}")]
		[ActionName("Details")]
		public async Task<IActionResult> DetailsAsync(long id)
		{
			var news = await _newsService.GetNewsAsync(id);
			if (news is not null)
			{
				var newsVM = _mapper.Map<NewsViewModel>(news);

				var courses = await _courseService.GetAllCoursesAsync();
				var coursesVM = _mapper.Map<List<CourseViewModel>>(courses);

				var page = new NewsDetailsViewModel
				{
					Header = new HeaderViewModel
					{
						Courses = coursesVM
					},
					News = newsVM
				};

				return View(page);
			}

			return NotFound();
		}
	}	
}
