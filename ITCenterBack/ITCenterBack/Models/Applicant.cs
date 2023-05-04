using System.ComponentModel.DataAnnotations;

namespace ITCenterBack.Models
{
	public class Applicant
	{
		[Key]
		public long Id { get; set; }
		public School School { get; set; }
		public long SchoolId { get; set; }
		public string? SchoolName { get; set; }
		public string ListenerFullName { get; set; }
		public string RepresentativeFullName { get; set; }
		public string RepresentativePhoneNumber { get; set; }
	}
}
