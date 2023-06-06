﻿using ITCenterBack.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ITCenterBack.ViewModels
{
    public class ContactsViewModel
    {
        public HeaderViewModel Header { get; set; }
        public List<CourseViewModel> Courses { get; set; }
        public List<SchoolViewModel> Schools { get; set; }
        public string? SchoolName { get; set; }
        public string Class { get; set; }
        public string PhoneNumber { get; set; }
        public string ListenerFullName { get; set; }
        public string RepresentativeFullName { get; set; }
        public string RepresentativePhoneNumber { get; set; }
        public List<TimeViewModel> Time { get; set; }
        public List<AvaliableTimesViewModel> AvaliableTime { get; set; }
        public FooterViewModel Footer { get; set; }
    }
}
