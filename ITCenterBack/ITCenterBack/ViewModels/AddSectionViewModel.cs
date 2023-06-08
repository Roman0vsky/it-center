using System.ComponentModel.DataAnnotations;

namespace ITCenterBack.ViewModels
{
	public class AddSectionViewModel
	{
		public string? Name { get; set; }
		[DataType(DataType.MultilineText)]
		public string? Description { get; set; }
	}
}
