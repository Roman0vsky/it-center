using ITCenterBack.Models;

namespace ITCenterBack.Interfaces
{
	public interface IAdministrationService
	{
		Task<Administration> GetAdministrationAsync(long id);
		Task<List<Administration>> GetAllAdministrationAsync();
		Task CreateAdministrationAsync(string name, string description, string image, string link, bool isAdmin, bool isHeadOfCourse);
		Task DeleteAdministrationAsync(long id);
	}
}
