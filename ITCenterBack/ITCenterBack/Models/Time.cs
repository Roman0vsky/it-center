using System.ComponentModel.DataAnnotations;

namespace ITCenterBack.Models
{
    public class Time
    {
        [Key]
        public long Id { get; set; }
        public string TimeInterval { get; set; }
        public DayOfWeek Day { get; set; }
        public bool IsAvaliable { get; set; }
    }
}
