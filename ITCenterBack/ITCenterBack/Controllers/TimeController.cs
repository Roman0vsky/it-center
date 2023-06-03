using AutoMapper;
using ITCenterBack.Constants;
using ITCenterBack.Interfaces;
using ITCenterBack.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

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
        public async Task<IActionResult> TimeAsync()
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
            
            var avaliableTime = await _avaliableTimeService.GetAllSlotsAsync();

            var page = new AvaliableTimeViewModel
            {
                AvaliableTimes = avaliableTime,
                Time = timeVM
            };

            return View(page);
        }

        [HttpPost]
        [ActionName("AvaliableTime")]
        [Route("AvaliableTime")]
        public async Task<IActionResult> SetAvaliableTimeAsync()
        {
            var time = await _timeService.GetTimesAsync();
            var timeVM = _mapper.Map<List<TimeViewModel>>(time);
            var avaliableTime = await _avaliableTimeService.GetAllSlotsAsync();
            var timeList = Request.Form["time"];
            //List<long> hourIds = new();
            //List<int> dayIndexes = new();

            var page = new AvaliableTimeViewModel
            {
                AvaliableTimes = avaliableTime,
                Time = timeVM
            };

            Regex regex = new Regex(@"\d+");

            if (!string.IsNullOrWhiteSpace(timeList))
            {
                await _avaliableTimeService.DisableAllAsync();

                int hourIndex;
                int dayIndex;

                for (int i = 0; i < timeList.Count(); i++)
                {
                    MatchCollection matches = regex.Matches(timeList[i]);

                    if (matches.Count > 0)
                    {
                        hourIndex = int.Parse(matches[0].Value);
                        dayIndex = int.Parse(matches[1].Value) + 1;

                        foreach(var avTime in avaliableTime)
                        {
                            if(avTime.TimeId == time[hourIndex].Id && avTime.Day == (DayOfWeek)dayIndex)
                            {
                                await _avaliableTimeService.SetAvaliableSlotAsync(avTime.Id);

                                break;
                            }
                        }
                    }
                }

            }

            return View(page);
        }
    }
}
