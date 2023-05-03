using System.ComponentModel.DataAnnotations;

namespace ITCenterBack.Models
{
    public class Schools
    {
        [Key]
        public long Id { get; set; }
        public string? Name { get; set; }
    }
}
