using AutoMapper;
using ITCenterBack.Constants;
using ITCenterBack.Interfaces;
using ITCenterBack.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITCenterBack.Controllers
{
    [Authorize(Policy = AccountPolicies.ElevatedRights, AuthenticationSchemes = "Identity.Application,Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class TimeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITimeService _timeService;
        private readonly IAvaliableTimeService _avaliableTimeService;

        public TimeController(IMapper mapper, ITimeService timeService, IAvaliableTimeService avaliableTimeService)
        {
            _mapper = mapper;
            _timeService = timeService;
            _avaliableTimeService = avaliableTimeService;
        }

        [HttpGet]
        [Route("Time")]
        [ActionName("Time")]
        public async Task<IActionResult> SocialLinksAsync()
        {
            var time = await _timeService.GetTimesAsync();
            var timeVM = _mapper.Map<List<TimeViewModel>>(time);

            return View(timeVM);
        }

        [HttpGet]
        [ActionName("AddTime")]
        [Route("AddTime")]
        public IActionResult AddSocialLinks()
        {
            return View();
        }

        [HttpPost]
        [ActionName("AddTime")]
        [Route("AddTime")]
        public async Task<IActionResult> PostAddSocialLinkAsync([FromForm] AddTimeViewModel viewModel)
        {
            await _timeService.CreateTimeAsync(viewModel.From, viewModel.To);

            return RedirectToAction("Time");
        }

        [HttpGet]
        [Route("DeleteTime")]
        [ActionName("DeleteTime")]
        public async Task<IActionResult> DeleteSocialLinkGetAsync(long id)
        {
            var time = await _timeService.GetTimeAsync(id);

            if (time is null)
            {
                return NotFound();
            }

            var timeVM = _mapper.Map<TimeViewModel>(time);

            return View(timeVM);
        }

        [HttpPost]
        [Route("DeleteTime")]
        [ActionName("DeleteTime")]
        public async Task<IActionResult> DeleteSocialLinkAsync(long id)
        {
            await _timeService.DeleteTimeAsync(id);

            return RedirectToAction("Time");
        }

        [HttpGet]
        [ActionName("AvaliableTime")]
        [Route("AvaliableTime")]
        public async Task<IActionResult> AvaliableTimeAsync()
        {
            var time = await _timeService.GetTimesAsync();
            var timeVM = _mapper.Map<List<TimeViewModel>>(time);

            var page = new AvaliableTimeViewModel
            {
                Time = timeVM
            };

            return View(page);
        }
    }
}
