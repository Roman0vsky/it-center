using System.ComponentModel.DataAnnotations;

namespace ITCenterBack.Models
{
    public class SliderImage
    {
        [Key]
        public long Id { get; set; }
        public string Image { get; set; }
    }
}
