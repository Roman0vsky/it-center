using ITCenterBack.Interfaces;
using ITCenterBack.Models;
using ITCenterBack.Repositories;
using System.Xml.Linq;

namespace ITCenterBack.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IRepository<Schedule> _scheduleRepository;

        public ScheduleService(IRepository<Schedule> scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public async Task CreateSchedule(string description, string image)
        {
            if (!string.IsNullOrWhiteSpace(description) && !string.IsNullOrWhiteSpace(image))
            {
                var schedule = new Schedule
                {
                    Description = description,
                    Image = image
                };

                await _scheduleRepository.CreateAsync(schedule);
            }
        }

        //to do
        public async Task UpdateSchedule(string description, string image)
        {
            if (!string.IsNullOrWhiteSpace(description) && !string.IsNullOrWhiteSpace(image))
            {
                var schedule = new Schedule
                {
                    Description = description,
                    Image = image
                };

                await _scheduleRepository.UpdateAsync(schedule);
            }
        }
    }
}
