using ITCenterBack.Models;

namespace ITCenterBack.ViewModels
{
    public class AvaliableTimesViewModel
    {
        public long Id { get; set; }
        public bool IsAvaliable { get; set; }
        public DayOfWeek Day { get; set; }
        public long TimeId { get; set; }
        public Time Time { get; set; }
        public DateTime TimeFrom { get; set; }
    }
}
