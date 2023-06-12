using ITCenterBack.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ITCenterBack.ViewModels
{
	public class ApplicationsViewModel
	{
		public SelectList Courses { get; set; }
		public List<ApplicationViewModel> Applications { get; set; }
	}
}
