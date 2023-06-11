using ITCenterBack.Interfaces;
using ITCenterBack.Models;

namespace ITCenterBack.Services
{
	public class AdministrationService : IAdministrationService
	{
		private readonly IRepository<Administration> _administrationRepository;

		public AdministrationService(IRepository<Administration> administrationRepository)
		{
			_administrationRepository = administrationRepository;
		}

		public async Task CreateAdministrationAsync(string name, string description, string image, string link, bool isAdmin, bool isHeadOfCourse)
		{
			if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(image))
			{
				var adm = new Administration
				{
					Name = name,
					Description = description,
					Image = image,
					Link = link,
					IsAdministrator = isAdmin,
					IsHeadOfThecenter = isHeadOfCourse
				};

				await _administrationRepository.CreateAsync(adm);
			}
		}

		public async Task DeleteAdministrationAsync(long id)
		{
			var adm = await _administrationRepository.GetByIdAsync(id);

			if(adm is not null)
			{
				await _administrationRepository.DeleteAsync(id);
			}
		}

		public async Task<Administration> GetAdministrationAsync(long id)
		{
			return await _administrationRepository.GetByIdAsync(id);
		}

		public async Task<List<Administration>> GetAllAdministrationAsync()
		{
			return await _administrationRepository.GetAllAsync();
		}
	}
}
