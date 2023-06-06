using ITCenterBack.Data;
using ITCenterBack.Interfaces;
using ITCenterBack.Models;

namespace ITCenterBack.Repositories
{
    public class ScheduleRepository : IRepository<Schedule>
    {
        private readonly ITCenterContext _context;

        public ScheduleRepository(ITCenterContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Schedule item)
        {
            await _context.Schedule.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Schedule>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Schedule> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Schedule item)
        {
            _context.Schedule.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
