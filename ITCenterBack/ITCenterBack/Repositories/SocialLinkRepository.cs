using ITCenterBack.Data;
using ITCenterBack.Interfaces;
using ITCenterBack.Models;
using Microsoft.EntityFrameworkCore;

namespace ITCenterBack.Repositories
{
	public class SocialLinkRepository : IRepository<SocialLink>
	{
		private readonly ITCenterContext _context;

		public SocialLinkRepository(ITCenterContext context)
		{
			_context = context;
		}

		public async Task CreateAsync(SocialLink item)
		{
			await _context.SocialLinks.AddAsync(item);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(long id)
		{
			var socialLink = await _context.SocialLinks.FirstOrDefaultAsync(p => p.Id == id);

			if (socialLink is not null)
			{
				_context.SocialLinks.Remove(socialLink);

				await _context.SaveChangesAsync();
			}
		}

		public async Task<List<SocialLink>> GetAllAsync()
		{
			return await _context.SocialLinks.ToListAsync();
		}

		public async Task<SocialLink> GetByIdAsync(long id)
		{
			return await _context.SocialLinks.FirstOrDefaultAsync(c => c.Id == id);
		}

		public async Task UpdateAsync(SocialLink item)
		{
			_context.SocialLinks.Update(item);
			await _context.SaveChangesAsync();
		}
	}
}
