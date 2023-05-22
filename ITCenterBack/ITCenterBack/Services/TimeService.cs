using ITCenterBack.Interfaces;
using ITCenterBack.Models;
using ITCenterBack.ViewModels;

namespace ITCenterBack.Services
{
    public class TimeService : ITimeService
    {
        private readonly IRepository<Time> _timeRepository;

        public TimeService(IRepository<Time> timeRepository)
        {
            _timeRepository = timeRepository;
        }

        public async Task CreateTimeAsync(DateTime from, DateTime to)
        {
            var time = new Time()
            {
                From = from,
                To = to
            };

            await _timeRepository.CreateAsync(time);
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
