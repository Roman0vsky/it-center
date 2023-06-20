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

        public async Task CreateNewsAsync(string title, string shortText, string text, string image)
        {
            if (!string.IsNullOrWhiteSpace(title))
            {
                var news = new News
                {
                    Title = title,
                    Text = text,
                    ShortText = shortText,
                    Image = image
                };

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

        public async Task UpdateNewsAsync(long id, DateTime date, string title, string shortText, string text, string image)
        {
            var news = await _newsRepository.GetByIdAsync(id);

            if (news is not null)
            {
                news.Text = text;
                news.ShortText = shortText;
                news.PublicationDate = date;
                news.Image = image;
                news.Title = title;

                await _newsRepository.UpdateAsync(news);
            }
        }
    }
}
