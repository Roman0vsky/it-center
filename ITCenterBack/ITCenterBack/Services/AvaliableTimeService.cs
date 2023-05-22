using ITCenterBack.Interfaces;
using ITCenterBack.Models;

namespace ITCenterBack.Services
{
	public class AvaliableTimeService : IAvaliableTimeService
	{
		private readonly IRepository<AvaliableTime> _avaliableTimeRepository;
		private readonly IRepository<Time> _timeRepository;

		public AvaliableTimeService(IRepository<AvaliableTime> avaliableTimeRepository, IRepository<Time> timeRepository)
		{
			_avaliableTimeRepository = avaliableTimeRepository;
			_timeRepository = timeRepository;
		}

        public async Task CreateSlotsForTimeAsync(long timeId)
        {
            var time = new AvaliableTime
            {
                IsAvaliable = false,
                TimeId = timeId
            };

            for(int i = 0; i < 7; i++)
            {
                time.Day = (DayOfWeek)i;

                await _avaliableTimeRepository.CreateAsync(time);
            }
        }

        public async Task DisableSlotAsync(long id)
        {
            var time = await _avaliableTimeRepository.GetByIdAsync(id);

            if(time is not null)
            {
                time.IsAvaliable = false;

                await _avaliableTimeRepository.UpdateAsync(time);
            }
        }

        public async Task<List<AvaliableTime>> GetAllSlotsAsync()
        {
            return await _avaliableTimeRepository.GetAllAsync();
        }

        public async Task SetAvaliableSlotAsync(long id)
        {
            var time = await _avaliableTimeRepository.GetByIdAsync(id);

            if (time is not null)
            {
                time.IsAvaliable = true;

                await _avaliableTimeRepository.UpdateAsync(time);
            }
        }
    }
}
