using ITCenterBack.Interfaces;
using ITCenterBack.Models;
using ITCenterBack.ViewModels;

namespace ITCenterBack.Services
{
    public class TimeService : ITimeService
    {
        private readonly IRepository<Time> _timeRepository;
        private readonly IRepository<AvaliableTime> _avaliableTimeRepository;

        public TimeService(IRepository<Time> timeRepository, IRepository<AvaliableTime> avaliableTimeRepository)
        {
            _timeRepository = timeRepository;
            _avaliableTimeRepository = avaliableTimeRepository;
        }

        public async Task CreateTimeAsync(DateTime from, DateTime to)
        {
            var time = new Time()
            {
                From = from,
                To = to
            };

            await _timeRepository.CreateAsync(time);

            //avaliable time create

            //var avTime = new AvaliableTime
            //{
            //    IsAvaliable = false,
            //    TimeId = time.Id
            //};

            //for (int i = 0; i < 7; i++)
            //{
            //    avTime.Day = (DayOfWeek)i;

            //    await _avaliableTimeRepository.CreateAsync(avTime);
            //}
        }

        public async Task DeleteTimeAsync(long id)
        {
            var time = await _timeRepository.GetByIdAsync(id);

            if(time is not null)
            {
                await _timeRepository.DeleteAsync(id);
            }
        }

        public async Task<Time> GetTimeAsync(long id)
        {
			var time = await _timeRepository.GetByIdAsync(id);

            return time;
		}

        public async Task<List<Time>> GetTimesAsync()
        {
            return await _timeRepository.GetAllAsync();
        }
    }
}
