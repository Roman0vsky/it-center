namespace ITCenterBack.ViewModels
{
    public class TeacherViewModel
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public List<CourseViewModel> Courses { get; set; }
        public string? Image { get; set; }
		public string? Link { get; set; }
	}
}
