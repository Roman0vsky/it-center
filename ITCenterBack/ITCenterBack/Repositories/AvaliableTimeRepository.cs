using ITCenterBack.Data;
using ITCenterBack.Interfaces;
using ITCenterBack.Models;
using Microsoft.EntityFrameworkCore;

namespace ITCenterBack.Repositories
{
	public class AvaliableTimeRepository : IRepository<AvaliableTime>
	{
		private readonly ITCenterContext _context;

		public AvaliableTimeRepository(ITCenterContext context)
		{
			_context = context;
		}

		public async Task CreateAsync(AvaliableTime item)
		{
			await _context.AvaliableTimes.AddAsync(item);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(long id)
		{
			var time = await _context.AvaliableTimes.FirstOrDefaultAsync(p => p.Id == id);

			if (time is not null)
			{
				_context.AvaliableTimes.Remove(time);

				await _context.SaveChangesAsync();
			}
		}

		public async Task<List<AvaliableTime>> GetAllAsync()
		{
			return await _context.AvaliableTimes.OrderBy(p => p.Day).ToListAsync();
		}

		public async Task<AvaliableTime> GetByIdAsync(long id)
		{
			return await _context.AvaliableTimes.FirstOrDefaultAsync(c => c.Id == id);
		}

		public async Task UpdateAsync(AvaliableTime item)
		{
			_context.AvaliableTimes.Update(item);
			await _context.SaveChangesAsync();
		}
	}
}
