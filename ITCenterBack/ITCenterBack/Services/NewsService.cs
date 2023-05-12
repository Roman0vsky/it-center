using ITCenterBack.Interfaces;
using ITCenterBack.Models;
using ITCenterBack.Repositories;

namespace ITCenterBack.Services
{
    public class NewsService : INewsService
    {
        private readonly IRepository<News> _newsRepository;

        public NewsService(IRepository<News> newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task CreateNewsAsync(News news)
        {
            if (news is not null)
            {
                await _newsRepository.CreateAsync(news);
            }

            //throw new Exception();
        }

        public async Task DeleteNewsAsync(long id)
        {
            await _newsRepository.DeleteAsync(id);
        }

        public async Task<List<News>> GetAllNewsAsync()
        {
            var courses = await _newsRepository.GetAllAsync();

            return courses;
        }

        public async Task<News> GetNewsAsync(long id)
        {
            return await _newsRepository.GetByIdAsync(id);
        }

        public async Task UpdateNewsAsync(News news)
        {
            if (news is not null)
            {
                await _newsRepository.UpdateAsync(news);
            }

            //throw new Exception();
        }
    }
}
