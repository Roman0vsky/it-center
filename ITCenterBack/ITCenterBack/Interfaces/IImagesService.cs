using ITCenterBack.Models;
using ITCenterBack.ViewModels;

namespace ITCenterBack.Interfaces
{
    public interface IImagesService
    {
        Task UpdateScheduleImage(string image);
        Task UpdateScheduleDescription(string description);
        Task AddSliderImage(string image);
        Task<List<SliderImage>> GetSliderImages();
        Task<SliderImage> GetSliderImage(long id);
        Task DeleteSliderImage(long id);
        Task<Schedule> GetSchedule(long id);
    }
}
