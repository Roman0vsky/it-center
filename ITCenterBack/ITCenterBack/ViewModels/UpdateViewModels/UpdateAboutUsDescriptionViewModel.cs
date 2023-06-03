using System.ComponentModel.DataAnnotations;

namespace ITCenterBack.ViewModels.UpdateViewModels
{
	public class UpdateAboutUsDescriptionViewModel
	{
		[DataType(DataType.MultilineText)]
		public string Description { get; set; }
	}
}
