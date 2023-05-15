using ITCenterBack.Models;

namespace ITCenterBack.Interfaces
{
    public interface INewsService
    {
        Task CreateNewsAsync(string title, string text, string image);
        Task DeleteNewsAsync(long id);
        Task UpdateNewsAsync(News news);
        Task<News> GetNewsAsync(long id);
        Task<List<News>> GetAllNewsAsync();
    }
}
