using ITCenterBack.Data;
using ITCenterBack.Interfaces;
using ITCenterBack.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace ITCenterBack.Services
{
	public class InfoService : IInfoService
	{
		private readonly ITCenterContext _context;

		public InfoService(ITCenterContext context)
		{
			_context = context;
		}

		public async Task<Info> GetInfoAsync()
		{
			return await _context.Info.FirstOrDefaultAsync();
		}

		public async Task UpdateAdressOfUniversityAsync(string adress)
		{
			var info = await _context.Info.FirstOrDefaultAsync();

			if (!string.IsNullOrWhiteSpace(adress))
			{
				if (info is null)
				{
					info = new Info
					{
						AdressOfUniversity = adress
					};

					_context.Info.Add(info);
					await _context.SaveChangesAsync();
				}
				else
				{
					info.AdressOfUniversity = adress;

					_context.Info.Update(info);
					await _context.SaveChangesAsync();
				}
			}
		}

		public async Task UpdateFooterLogoAsync(string logo)
		{
			var info = await _context.Info.FirstOrDefaultAsync();

			if (!string.IsNullOrWhiteSpace(logo))
			{
				if (info is null)
				{
					info = new Info
					{
						FooterLogo = logo
					};

					_context.Info.Add(info);
					await _context.SaveChangesAsync();
				}
				else
				{
					info.FooterLogo = logo;

					_context.Info.Update(info);
					await _context.SaveChangesAsync();
				}
			}
		}

		public async Task UpdateHeaderLogoAsync(string logo)
		{
			var info = await _context.Info.FirstOrDefaultAsync();

			if (!string.IsNullOrWhiteSpace(logo))
			{
				if (info is null)
				{
					info = new Info
					{
						HeaderLogo = logo
					};

					_context.Info.Add(info);
					await _context.SaveChangesAsync();
				}
				else
				{
					info.HeaderLogo = logo;

					_context.Info.Update(info);
					await _context.SaveChangesAsync();
				}
			}
		}

		public async Task UpdateNameOfTheCenterAsync(string name)
		{
			var info = await _context.Info.FirstOrDefaultAsync();

			if (!string.IsNullOrWhiteSpace(name))
			{
				if (info is null)
				{
					info = new Info
					{
						NameOfTheCenter = name
					};

					_context.Info.Add(info);
					await _context.SaveChangesAsync();
				}
				else
				{
					info.NameOfTheCenter = name;

					_context.Info.Update(info);
					await _context.SaveChangesAsync();
				}
			}
		}

		public async Task UpdateNameOfUniversityAsync(string name)
		{
			var info = await _context.Info.FirstOrDefaultAsync();

			if (!string.IsNullOrWhiteSpace(name))
			{
				if (info is null)
				{
					info = new Info
					{
						NameOfUniversity = name
					};

					_context.Info.Add(info);
					await _context.SaveChangesAsync();
				}
				else
				{
					info.NameOfUniversity = name;

					_context.Info.Update(info);
					await _context.SaveChangesAsync();
				}
			}
		}

		public async Task UpdateSliderFirstTextAsync(string text)
		{
			var info = await _context.Info.FirstOrDefaultAsync();

			if (!string.IsNullOrWhiteSpace(text))
			{
				if (info is null)
				{
					info = new Info
					{
						SliderFirstText = text
					};

					_context.Info.Add(info);
					await _context.SaveChangesAsync();
				}
				else
				{
					info.SliderFirstText = text;

					_context.Info.Update(info);
					await _context.SaveChangesAsync();
				}
			}
		}

		public async Task UpdateSliderSecondTextAsync(string text)
		{
			var info = await _context.Info.FirstOrDefaultAsync();

			if (!string.IsNullOrWhiteSpace(text))
			{
				if (info is null)
				{
					info = new Info
					{
						SliderSecondText = text
					};

					_context.Info.Add(info);
					await _context.SaveChangesAsync();
				}
				else
				{
					info.SliderSecondText = text;

					_context.Info.Update(info);
					await _context.SaveChangesAsync();
				}
			}
		}

        public async Task UpdateSliderThirdTextAsync(string text)
        {
            var info = await _context.Info.FirstOrDefaultAsync();

            if (!string.IsNullOrWhiteSpace(text))
            {
                if (info is null)
                {
                    info = new Info
                    {
                        SliderThirdText = text
                    };

                    _context.Info.Add(info);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    info.SliderThirdText = text;

                    _context.Info.Update(info);
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}
