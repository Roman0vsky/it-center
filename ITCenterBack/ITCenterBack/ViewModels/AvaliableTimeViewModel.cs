using ITCenterBack.Models;

namespace ITCenterBack.ViewModels
{
	public class AvaliableTimeViewModel
	{
		public long Id { get; set; }
		public bool IsAvaliable { get; set; }
		public DayOfWeek Day { get; set; }
		public List<TimeViewModel> Time { get; set; }
	}
}
