using ITCenterBack.Interfaces;
using ITCenterBack.Models;

namespace ITCenterBack.Services
{
    public class NewsService //: INewsService
    {
        private readonly IRepository<News> _newsRepository;

        public NewsService(IRepository<News> newsRepository)
        {
            _newsRepository = newsRepository;
        }
    }
}
