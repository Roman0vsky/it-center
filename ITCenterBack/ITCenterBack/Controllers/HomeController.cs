using AutoMapper;
using ITCenterBack.Interfaces;
using ITCenterBack.Models;
using ITCenterBack.Services;
using ITCenterBack.Utilities;
using ITCenterBack.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using System.Text.RegularExpressions;

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
        private readonly ISectionService _sectionService;
        private readonly IApplicationService _applicationService;
        private readonly ITimeService _timeService;
        private readonly IAvaliableTimeService _avTimeService;
		private readonly IAboutUsService _aboutUsService;
		private readonly IInfoService _infoService;
        private readonly ISquareService _squareService;
        private readonly IMapper _mapper;
		private readonly IOptions<JwtConfigurationModel> _jwtConfig;

        public HomeController(ICourseService courseService, IAccountService accountService, ISchoolService schoolService, INewsService newsService, ISocialLinkService linkService, 
            IImagesService imagesService, ISectionService sectionService, IApplicationService applicationService, ITimeService timeService, IAvaliableTimeService avTimeService, 
            IAboutUsService aboutUsService, IInfoService infoService, ISquareService squareService, IMapper mapper, IOptions<JwtConfigurationModel> jwtConfig)
        {
            _courseService = courseService;
            _accountService = accountService;
            _schoolService = schoolService;
            _newsService = newsService;
            _linkService = linkService;
            _imagesService = imagesService;
            _sectionService = sectionService;
            _applicationService = applicationService;
            _timeService = timeService;
            _avTimeService = avTimeService;
            _aboutUsService = aboutUsService;
            _infoService = infoService;
            _squareService = squareService;
            _mapper = mapper;
            _jwtConfig = jwtConfig;
        }

        private async Task<HeaderViewModel> HeaderInfoAsync ()
        {
            var sections = await _sectionService.GetAllSections();
            var sectionsVM = _mapper.Map<List<SectionViewModel>>(sections);

            var links = await _linkService.GetAllSocialLinksAsync();
            var linksVM = _mapper.Map<List<SocialLinkViewModel>>(links);

			var info = await _infoService.GetInfoAsync();
			var infoVM = _mapper.Map<InfoViewModel>(info);

			var header = new HeaderViewModel
			{
				Sections = sectionsVM,
				Links = linksVM,
				Info = infoVM
			};

			return header;
		}

		[Route("Index")]
        public async Task<IActionResult> IndexAsync(CourseType courseType = CourseType.All)
        {
            var courses = await _courseService.GetAllCoursesAsync();
            var coursesVM = _mapper.Map<List<CourseViewModel>>(courses);

            var sliderImages = await _imagesService.GetSliderImagesAsync();
            var sliderImagesVM = _mapper.Map<List<SliderImageViewModel>>(sliderImages);

            var aboutUs = await _aboutUsService.GetAboutUs();
            var aboutUsVM = _mapper.Map<AboutUsViewModel>(aboutUs);

            var info = await _infoService.GetInfoAsync();
            var infoVM = _mapper.Map<InfoViewModel>(info);

            var squares = await _squareService.GetAllSquares();
            var squaresVM = _mapper.Map<List<SquareViewModel>>(squares);

			var header = await HeaderInfoAsync();

            var links = await _linkService.GetAllSocialLinksAsync();
            var linksVM = _mapper.Map<List<SocialLinkViewModel>>(links);

            var footer = new FooterViewModel
            {
                Info = infoVM
            };

            var page = new IndexViewModel
            {
                Header = header,
                SliderImages = sliderImagesVM,
                AboutUs = aboutUsVM,
                Info = infoVM,
                Footer = footer,
                Squares = squaresVM
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
        [ActionName("Apllication")]
        [Route("Apllication")]
        public async Task<IActionResult> ApllicationAsync()
        {
            var courses = await _courseService.GetAllCoursesAsync();
            var coursesVM = _mapper.Map<List<CourseViewModel>>(courses);

            var schools = await _schoolService.GetAllSchoolsAsync();
            var schoolsVM = _mapper.Map<List<SchoolViewModel>>(schools);

            var header = await HeaderInfoAsync();

            var info = await _infoService.GetInfoAsync();
            var infoVM = _mapper.Map<InfoViewModel>(info);

            var links = await _linkService.GetAllSocialLinksAsync();
            var linksVM = _mapper.Map<List<SocialLinkViewModel>>(links);

            var footer = new FooterViewModel
            {
                Info = infoVM
            };

            var time = await _timeService.GetTimesAsync();
            var timeVM = _mapper.Map<List<TimeViewModel>>(time);

            var avTime = await _avTimeService.GetAllSlotsAsync();
            var avTimeVM = _mapper.Map<List<AvaliableTimesViewModel>>(avTime);

            var page = new MakeApplicationViewModel
            {
                Header = header,
				Schools = schoolsVM, /*new SelectList(schoolsVM, "Id", "Name"),*/
                Courses = coursesVM,
                Time = timeVM,
                AvaliableTime = avTimeVM,
                Footer = footer
            };

            return View(page);
        }

        [HttpPost]
        [ActionName("Apllication")]
        [Route("Apllication")]
        public async Task<IActionResult> PostApllicationAsync()
        {
            string fio = Request.Form["contact_fio"];
            var schoolId = Request.Form["choose-school__select"];
            string schoolNameAlt = Request.Form["school-number"];
            var classNumber = int.Parse(Request.Form["class-number"]);
            string repPhone = Request.Form["rep-phone"];
            string repFio = Request.Form["rep-fio"];
            var coursesId = Request.Form["courses"].Select(long.Parse).ToList();

            var time = await _timeService.GetTimesAsync();
            var avaliableTime = await _avTimeService.GetAllSlotsAsync();

            var avTimeList = new List<AvaliableTime>();

            var timeList = Request.Form["time"];

            Regex regex = new Regex(@"\d+");

            if (!string.IsNullOrWhiteSpace(timeList))
            {
                int hourIndex;
                int dayIndex;

                for (int i = 0; i < timeList.Count(); i++)
                {
                    MatchCollection matches = regex.Matches(timeList[i]);

                    if (matches.Count > 0)
                    {
                        hourIndex = int.Parse(matches[0].Value);
                        dayIndex = int.Parse(matches[1].Value) + 1;

                        foreach (var avTime in avaliableTime)
                        {
                            if (avTime.TimeId == time[hourIndex].Id && avTime.Day == (DayOfWeek)dayIndex)
                            {
                                avTimeList.Add(avTime);

                                break;
                            }
                        }
                    }
                }

            }

            if (string.IsNullOrWhiteSpace(schoolId))
            {
                await _applicationService.CreateApplication(schoolNameAlt, classNumber, fio, repFio, repPhone, avTimeList, coursesId);
                return RedirectToAction("Apllication");
            }

            long id = long.Parse(schoolId);

			await _applicationService.CreateApplication(id, classNumber, fio, repFio, repPhone, avTimeList, coursesId);

            return RedirectToAction("Apllication");
        }

        [HttpGet]
        [ActionName("Schedule")]
        [Route("Schedule")]
        public async Task<IActionResult> ScheduleAsync()
        {
            var schedule = await _imagesService.GetScheduleAsync();

            var header = await HeaderInfoAsync();

            var info = await _infoService.GetInfoAsync();
            var infoVM = _mapper.Map<InfoViewModel>(info);

            var links = await _linkService.GetAllSocialLinksAsync();
            var linksVM = _mapper.Map<List<SocialLinkViewModel>>(links);

            var footer = new FooterViewModel
            {
                Info = infoVM
            };

            var page = new ScheduleViewModel
            {
                Header = header,
                Footer = footer
			};

            if(schedule is not null)
            {
                if(!string.IsNullOrWhiteSpace(schedule.Description))
                {
					page.Description = schedule.Description;
				}

				if (!string.IsNullOrWhiteSpace(schedule.Image))
				{
					page.Image = schedule.Image; ;
				}
            }

            return View(page);
        }

        [HttpPost]
        [ActionName("Schedule")]
        public IActionResult PostScheduleAsync()
        {
            return View();
        }

        [HttpGet]
        [ActionName("Contacts")]
        [Route("Contacts")]
        public async Task<IActionResult> ContactsAsync()
        {
            var header = await HeaderInfoAsync();

            var info = await _infoService.GetInfoAsync();
            var infoVM = _mapper.Map<InfoViewModel>(info);

            var footer = new FooterViewModel
            {
                Info = infoVM
            };

            var page = new ContactsViewModel
            {
                Header = header,
                Footer = footer
            };

            return View(page);
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
