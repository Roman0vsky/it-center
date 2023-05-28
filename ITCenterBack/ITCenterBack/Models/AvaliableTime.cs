using System.ComponentModel.DataAnnotations;

namespace ITCenterBack.Models
{
	public class AvaliableTime
	{
		[Key]
		public long Id { get; set; }
		public bool IsAvaliable { get; set; }
		public DayOfWeek Day { get; set; }
		public long TimeId { get; set; }
		public Time Time { get; set; }
		public DateTime TimeFrom { get; set; }
	}
}
