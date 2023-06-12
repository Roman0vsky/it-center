using ITCenterBack.Models;

namespace ITCenterBack.ViewModels
{
    public class ApplicationViewModel
    {
        public long Id { get; set; }
        public string? SchoolName { get; set; }
        public int Class { get; set; }
        public string ListenerFullName { get; set; }
        public string RepresentativeFullName { get; set; }
        public string RepresentativePhoneNumber { get; set; }
		public List<string> Courses { get; set; }
		public DateTime Time { get; set; }
	}
}
