using ITCenterBack.Data;
using ITCenterBack.Interfaces;
using ITCenterBack.Models;
using ITCenterBack.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ITCenterBack.Services
{
    public class ImagesService : IImagesService
    {
        private readonly ITCenterContext _context;

        public ImagesService(ITCenterContext context)
        {
            _context = context;
        }

        public async Task AddSliderImage(string image)
        {
            var slider = new SliderImage
            {
                Image = image
            };

            await _context.SliderImages.AddAsync(slider);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSliderImage(long id)
        {
            var slider = await _context.SliderImages.FirstOrDefaultAsync(m => m.Id == id);

            if(slider is not null)
            {
                _context.SliderImages.Remove(slider);

                await _context.SaveChangesAsync();
            };
        }

        public async Task<Schedule> GetSchedule(long id)
        {
            return await _context.Schedule.FirstAsync();
        }

        public async Task<SliderImage> GetSliderImage(long id)
        {
            return await _context.SliderImages.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<SliderImage>> GetSliderImages()
        {
            return await _context.SliderImages.ToListAsync();
        }

        public async Task UpdateScheduleDescription(string description)
        {
            var scheldue = await _context.Schedule.FirstAsync();

            if (scheldue != null)
            {
                scheldue.Description = description;

                _context.Schedule.Update(scheldue);
                await _context.SaveChangesAsync();
            }
            else
            {
                scheldue = new Schedule
                {
                    Description = description
                };

                await _context.Schedule.AddAsync(scheldue);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateScheduleImage(string image)
        {
            var scheldue = await _context.Schedule.FirstAsync();

            if (scheldue != null) 
            { 
                scheldue.Image = image;

                _context.Schedule.Update(scheldue);
                await _context.SaveChangesAsync();
            }
            else
            {
                scheldue = new Schedule 
                { 
                    Image = image
                };

                await _context.Schedule.AddAsync(scheldue);
                await _context.SaveChangesAsync();
            }
        }
    }
}
