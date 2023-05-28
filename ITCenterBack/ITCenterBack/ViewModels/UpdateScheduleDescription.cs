using System.ComponentModel.DataAnnotations;

namespace ITCenterBack.ViewModels
{
	public class UpdateScheduleDescription
	{
		[DataType(DataType.MultilineText)]
		public string? Description { get; set; }
	}
}
