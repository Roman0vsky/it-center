using ITCenterBack.Data;
using ITCenterBack.Interfaces;
using ITCenterBack.Models;
using Microsoft.EntityFrameworkCore;

namespace ITCenterBack.Repositories
{
	public class SquareRepository : IRepository<Square>
	{
		private readonly ITCenterContext _context;

		public SquareRepository(ITCenterContext context)
		{
			_context = context;
		}

		public async Task CreateAsync(Square item)
		{
			await _context.Squares.AddAsync(item);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(long id)
		{
			var square = await _context.Squares.FirstOrDefaultAsync(p => p.Id == id);

			if (square is not null)
			{
				_context.Squares.Remove(square);

				await _context.SaveChangesAsync();
			}
		}

		public async Task<List<Square>> GetAllAsync()
		{
			return await _context.Squares.ToListAsync();
		}

		public async Task<Square> GetByIdAsync(long id)
		{
			return await _context.Squares.FirstOrDefaultAsync(c => c.Id == id);
		}

		public async Task UpdateAsync(Square item)
		{
			_context.Squares.Update(item);
			await _context.SaveChangesAsync();
		}
	}
}
