
using System.ComponentModel.DataAnnotations;

namespace ITCenterBack.Models
{
	public class TeacherCourses
	{
		[Key]
		public long Id { get; set; }
		public long CoursesId { get; set;}
		public long TeacherId { get; set; }
	}
}
