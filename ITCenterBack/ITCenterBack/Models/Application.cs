using System.ComponentModel.DataAnnotations;

namespace ITCenterBack.Models
{
    public class Application
    {
        [Key]
        public long Id { get; set; }
        public Applicant Applicant { get; set; }
        public long ApplicantId { get; set; }
        public Course Course { get; set;}
        public long CourseId { get; set; }
    }
}
