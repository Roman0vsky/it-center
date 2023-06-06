using ITCenterBack.Data;
using ITCenterBack.Interfaces;
using ITCenterBack.Models;
using Microsoft.EntityFrameworkCore;

namespace ITCenterBack.Repositories
{
    public class NewsRepository : IRepository<News>
    {
        private readonly ITCenterContext _context;

        public NewsRepository(ITCenterContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(News item)
        {
            await _context.News.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
			var news = await _context.News.FirstOrDefaultAsync(p => p.Id == id);

			if (news is not null)
			{
				_context.News.Remove(news);

				await _context.SaveChangesAsync();
			}
        }

        public async Task<List<News>> GetAllAsync()
        {
            return await _context.News.OrderBy(p => p.PublicationDate).ToListAsync();
        }

        public async Task<News> GetByIdAsync(long id)
        {
            return await _context.News.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(News item)
        {
            _context.News.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
