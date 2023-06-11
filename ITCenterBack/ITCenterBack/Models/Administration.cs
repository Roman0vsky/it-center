using System.ComponentModel.DataAnnotations;

namespace ITCenterBack.Models
{
	public class Administration
	{
		[Key]
		public long Id { get; set; }
		public string? Image { get; set; }
		public string? Description { get; set; }
		public string? Name { get; set; }
		public string? Link { get; set; }
		public bool IsAdministrator { get; set; }
		public bool IsHeadOfThecenter { get; set; }
	}
}
