using ITCenterBack.Data;
using ITCenterBack.Interfaces;
using ITCenterBack.Models;
using Microsoft.EntityFrameworkCore;

namespace ITCenterBack.Services
{
	public class AboutUsService : IAboutUsService
	{
		private readonly ITCenterContext _context;

		public AboutUsService(ITCenterContext context)
		{
			_context = context;
		}

		public async Task<AboutUs> GetAboutUs()
		{
			return await _context.AboutUs.FirstAsync();
		}

		public async Task UpdateDescriptionAsync(string description)
		{
			var about = await _context.AboutUs.FirstOrDefaultAsync();

			if (!string.IsNullOrWhiteSpace(description))
			{
				if (about is null)
				{
					about = new AboutUs 
					{ 
						Description = description 
					};

					_context.AboutUs.Add(about);
					await _context.SaveChangesAsync();
				}
				else
				{
					about.Description = description;

					_context.AboutUs.Update(about);
					await _context.SaveChangesAsync();
				}
			}
		}

		public async Task UpdateUrlAsync(string url)
		{
			var about = await _context.AboutUs.FirstOrDefaultAsync();

			if (!string.IsNullOrWhiteSpace(url))
			{
				if (about is null)
				{
					about = new AboutUs
					{
						Url = url
					};

					_context.AboutUs.Add(about);
					await _context.SaveChangesAsync();
				}
				else
				{
					about.Url = url;

					_context.AboutUs.Update(about);
					await _context.SaveChangesAsync();
				}
			}
		}
	}
}
