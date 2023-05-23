using ITCenterBack.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ITCenterBack.ViewModels
{
    public class ContactsViewModel
    {
        public HeaderViewModel Header { get; set; }
        public List<CourseViewModel> Courses { get; set; }
        public SelectList Schools { get; set; }
        public string? SchoolName { get; set; }
        public int Class { get; set; }
        public string PhoneNumber { get; set; }
        public string ListenerFullName { get; set; }
        public string RepresentativeFullName { get; set; }
        public string RepresentativePhoneNumber { get; set; }
        public List<Time> Time { get; set; }
        public List<AvaliableTime> AvaliableTime { get; set; }
    }
}
