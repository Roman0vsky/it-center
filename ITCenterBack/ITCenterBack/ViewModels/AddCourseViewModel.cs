using ITCenterBack.Models;
using System.ComponentModel.DataAnnotations;

namespace ITCenterBack.ViewModels
{
	public class AddCourseViewModel
	{
		public string Name { get; set; }
		public string Age { get; set; }
		[DataType(DataType.MultilineText)]
		public string Description { get; set; }
		[DataType(DataType.MultilineText)]
		public string Requirements { get; set; }
        public CourseType CourseType { get; set; }
    }
}
