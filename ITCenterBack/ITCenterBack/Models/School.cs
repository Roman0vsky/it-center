using System.ComponentModel.DataAnnotations;

namespace ITCenterBack.Models
{
    public class School
    {
        [Key]
        public long Id { get; set; }
        public string? Name { get; set; }
    }
}
