using ITCenterBack.Models;

namespace ITCenterBack.Interfaces
{
	public interface ISocialLinkService
	{
		Task CreateSocialLinkAsync(string name, string url);
		Task DeleteSocialLinkAsync(long id);
		Task UpdateSocialLinkAsync(long id, string name, string url);
		Task<SocialLink> GetSocialLinkAsync(long id);
		Task<List<SocialLink>> GetAllSocialLinksAsync();
	}
}
