using System.ComponentModel.DataAnnotations;

namespace ITCenterBack.Models
{
    public class CourseApplication
    {
        [Key]
        public long Id { get; set; }
        public Application Application { get; set; }
        public long ApplicationId { get; set; }
        public Course Course { get; set; }
        public long CourseId { get; set; }
    }
}
