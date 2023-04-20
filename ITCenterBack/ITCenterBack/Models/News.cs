using System.ComponentModel.DataAnnotations;

namespace ITCenterBack.Models
{
    public class News
    {
        [Key]
        public long Id { get; set; }
        public DateTime PublicationDate { get; set; }
        public string? Text { get; set; }
        public string? Image { get; set; }
    }
}
