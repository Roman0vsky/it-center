using ITCenterBack.Models;

namespace ITCenterBack.Interfaces
{
    public interface INewsService
    {
        Task CreateNewsAsync(string title, string shortText, string text, string image);
        Task DeleteNewsAsync(long id);
        Task UpdateNewsAsync(long id, DateTime date, string title, string shortText, string text, string image);
        Task<News> GetNewsAsync(long id);
        Task<List<News>> GetAllNewsAsync();
    }
}
