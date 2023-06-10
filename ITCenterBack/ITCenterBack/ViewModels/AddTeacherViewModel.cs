namespace ITCenterBack.ViewModels
{
	public class AddTeacherViewModel
	{
		public string Name { get; set; }
		public string? Image { get; set; }
		public string? Link { get; set; }
		public List<CourseViewModel> Courses { get; set; }
	}
}
