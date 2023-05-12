using ITCenterBack.Models;

namespace ITCenterBack.ViewModels
{
	public class AddCourseViewModel
	{
		public string Name { get; set; }
		public string Image { get; set; }
		public string Age { get; set; }
		public string Description { get; set; }
		public string Requirements { get; set; }
        public CourseType CourseType { get; set; }
    }
}
