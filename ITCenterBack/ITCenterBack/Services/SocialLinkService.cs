using ITCenterBack.Interfaces;
using ITCenterBack.Models;

namespace ITCenterBack.Services
{
	public class SocialLinkService : ISocialLinkService
	{
		private readonly IRepository<SocialLink> _socialLinkRepository;

		public SocialLinkService(IRepository<SocialLink> socialLinkRepository)
		{
			_socialLinkRepository = socialLinkRepository;
		}

		public async Task CreateSocialLinkAsync(string name, string url)
		{
			if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(url))
			{
				var link = new SocialLink()
				{
					Name = name,
					Url = url
				};

				await _socialLinkRepository.CreateAsync(link);
			}
		}

		public async Task DeleteSocialLinkAsync(long id)
		{
			var link = await _socialLinkRepository.GetByIdAsync(id);

			if(link is not null)
			{
				await _socialLinkRepository.DeleteAsync(id);
			}
		}

		public async Task<List<SocialLink>> GetAllSocialLinksAsync()
		{
			return await _socialLinkRepository.GetAllAsync();
		}

		public async Task<SocialLink> GetSocialLinkAsync(long id)
		{
			return await _socialLinkRepository.GetByIdAsync(id);
		}

		public async Task UpdateSocialLinkAsync(long id, string name, string url)
		{
			var link = await _socialLinkRepository.GetByIdAsync(id);

			if(link is not null)
			{
				link.Name = name;
				link.Url = url;

				await _socialLinkRepository.UpdateAsync(link);
			}
		}
	}
}
