using System.ComponentModel.DataAnnotations;

namespace ITCenterBack.Models
{
	public class ApplicationTime
	{
		[Key]
		public long Id { get; set; }
		public Application Application { get; set; }
		public long ApplicationId { get; set; }
		public Time Time { get; set; }
		public long TimeId { get; set; }
	}
}
