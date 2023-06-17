using ITCenterBack.Models;
using System.ComponentModel.DataAnnotations;

namespace ITCenterBack.ViewModels
{
	public class AddCourseViewModel
	{
		public string Name { get; set; }
		public string Age { get; set; }
		[DataType(DataType.Text)]
		public string Description { get; set; }
		[DataType(DataType.Text)]
		public string Requirements { get; set; }
    }
}
