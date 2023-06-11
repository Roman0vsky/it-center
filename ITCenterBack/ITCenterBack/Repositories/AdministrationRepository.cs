using ITCenterBack.Data;
using ITCenterBack.Interfaces;
using ITCenterBack.Models;
using Microsoft.EntityFrameworkCore;

namespace ITCenterBack.Repositories
{
	public class AdministrationRepository : IRepository<Administration>
	{
		private readonly ITCenterContext _context;

		public AdministrationRepository(ITCenterContext context)
		{
			_context = context;
		}

		public async Task CreateAsync(Administration item)
		{
			await _context.Administration.AddAsync(item);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(long id)
		{
			var administration = await _context.Administration.FirstOrDefaultAsync(p => p.Id == id);

			if (administration is not null)
			{
				_context.Administration.Remove(administration);

				await _context.SaveChangesAsync();
			}
		}

		public async Task<List<Administration>> GetAllAsync()
		{
			return await _context.Administration.ToListAsync();
		}

		public async Task<Administration> GetByIdAsync(long id)
		{
			return await _context.Administration.FirstOrDefaultAsync(c => c.Id == id);
		}

		public async Task UpdateAsync(Administration item)
		{
			_context.Administration.Update(item);
			await _context.SaveChangesAsync();
		}
	}
}
