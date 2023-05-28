using ITCenterBack.Models;
using ITCenterBack.ViewModels;

namespace ITCenterBack.Interfaces
{
    public interface IImagesService
    {
        Task UpdateScheduleImageAsync(string image);
        Task UpdateScheduleDescriptionAsync(string description);
        Task AddSliderImageAsync(string image);
        Task<List<SliderImage>> GetSliderImagesAsync();
        Task<SliderImage> GetSliderImageAsync(long id);
        Task DeleteSliderImageAsync(long id);
        Task<Schedule> GetScheduleAsync();
    }
}
