using ITCenterBack.Models;

namespace ITCenterBack.Interfaces
{
	public interface IInfoService
	{
		Task UpdateSliderBigTextAsync(string text);
		Task UpdateSliderSmallTextAsync(string text);
		Task UpdateNameOfTheCenterAsync(string name);
		Task UpdateHeaderLogoAsync(string logo);
		Task UpdateFooterLogoAsync(string logo);
		Task UpdateNameOfUniversityAsync(string name);
		Task UpdateAdressOfUniversityAsync(string adress);
		Task<Info> GetInfoAsync();
	}
}
