using System.ComponentModel.DataAnnotations;

namespace ITCenterBack.ViewModels
{
	public class AddTimeViewModel
	{
		[Required]
		[DataType(DataType.Time)]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
		public DateTime From { get; set; }
		[Required]
		[DataType(DataType.Time)]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
		public DateTime To { get; set; }
	}
}
