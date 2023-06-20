using ITCenterBack.Interfaces;
using ITCenterBack.Models;
using ITCenterBack.Repositories;
using static System.Net.Mime.MediaTypeNames;

namespace ITCenterBack.Services
{
    public class SectionService : ISectionService
    {
        private readonly IRepository<Section> _sectionRepository;

        public SectionService(IRepository<Section> sectionRepository)
        {
            _sectionRepository = sectionRepository;
        }

        public async Task CreateSectionAsync(string name, string description, string image)
        {
            if(!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(description))
            {
                await _sectionRepository.CreateAsync(
                    new Section
                    {
                        Name = name,
                        Description = description,
                        Image = image
                    }
                    );
            }
        }

        public async Task DeleteSectionAsync(long id)
        {
            var section = await _sectionRepository.GetByIdAsync(id);

            if(section is not null)
            {
                await _sectionRepository.DeleteAsync(id);
            }    
        }

        public async Task<List<Section>> GetAllSections()
        {
            return await _sectionRepository.GetAllAsync();
        }

        public async Task<Section> GetSectionAsync(long id)
        {
            return await _sectionRepository.GetByIdAsync(id);
        }

        public async Task UpdateSectionAsync(long id, string name, string description, string image)
        {
            var section = await _sectionRepository.GetByIdAsync(id);

            if (section is not null)
            {
                section.Description = description;
                section.Image = image;
                section.Name = name;

                await _sectionRepository.UpdateAsync(section);
            }
        }
    }
}
