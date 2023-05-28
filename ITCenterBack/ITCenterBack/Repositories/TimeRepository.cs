using ITCenterBack.Data;
using ITCenterBack.Interfaces;
using ITCenterBack.Models;
using Microsoft.EntityFrameworkCore;

namespace ITCenterBack.Repositories
{
    public class TimeRepository : IRepository<Time>
    {
        private readonly ITCenterContext _context;

        public TimeRepository(ITCenterContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Time item)
        {
            await _context.Times.AddAsync(item);
            await _context.SaveChangesAsync();

            var avTime = new List<AvaliableTime>();

            for(int i = 1; i <= 7; i++)
            {
                avTime.Add(new AvaliableTime()
                {
                    IsAvaliable = false,
                    TimeId = item.Id,
                    TimeFrom = item.From,
                    Day = (DayOfWeek)i
                });
            }

            await _context.AvaliableTimes.AddRangeAsync(avTime);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var time = await _context.Times.FirstOrDefaultAsync(p => p.Id == id);

            if (time is not null)
            {
                _context.Times.Remove(time);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Time>> GetAllAsync()
        {
            return await _context.Times.OrderBy(p => p.From.TimeOfDay).ToListAsync();
        }

        public async Task<Time> GetByIdAsync(long id)
        {
            return await _context.Times.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(Time item)
        {
            _context.Times.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
