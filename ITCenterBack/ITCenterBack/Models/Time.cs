using System.ComponentModel.DataAnnotations;

namespace ITCenterBack.Models
{
    public class Time
    {
        [Key]
        public long Id { get; set; }
		public DateTime From { get; set; }
		public DateTime To { get; set; }
	}
}
