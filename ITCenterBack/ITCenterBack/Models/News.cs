using System.ComponentModel.DataAnnotations;

namespace ITCenterBack.Models
{
    public class News
    {
        [Key]
        public long Id { get; set; }
        public string Title { get; set; }
        public DateTime PublicationDate { get; set; } = DateTime.Now;
        public string? Text { get; set; }
        public string? Image { get; set; }
    }
}
