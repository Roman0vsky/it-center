﻿using ITCenterBack.Models;

namespace ITCenterBack.Interfaces
{
	public interface IInfoService
	{
		Task UpdateSliderFirstTextAsync(string text);
		Task UpdateSliderSecondTextAsync(string text);
        Task UpdateSliderThirdTextAsync(string text);
        Task UpdateNameOfTheCenterAsync(string name);
		Task UpdateHeaderLogoAsync(string logo);
		Task UpdateFooterLogoAsync(string logo);
		Task UpdateNameOfUniversityAsync(string name);
		Task UpdateAdressOfUniversityAsync(string adress);
		Task UpdateFirstPhoneNumberAsync(string phone);
		Task UpdateSecondPhoneNumberAsync(string phone);
		Task UpdateEmailAsync(string email);
		Task UpdateSchoolYearAsync(string year);
		Task<Info> GetInfoAsync();
	}
}
