using ITCenterBack.Models;

namespace ITCenterBack.Interfaces
{
	public interface IAboutUsService
	{
		Task UpdateDescriptionAsync(string description);
		Task UpdateUrlAsync(string url);
		Task<AboutUs> GetAboutUs();
	}
}
