using System.ComponentModel.DataAnnotations;

namespace ITCenterBack.Models
{
    public class AboutUs
    {
        [Key]
        public long Id { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
    }
}
