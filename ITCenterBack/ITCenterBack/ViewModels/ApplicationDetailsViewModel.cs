﻿using ITCenterBack.Models;
using ITCenterBack.ViewModels.SecondaryViewModels;

namespace ITCenterBack.ViewModels
{
	public class ApplicationDetailsViewModel
	{
		public string? SchoolName { get; set; }
		public int Class { get; set; }
		public string ListenerFullName { get; set; }
		public string RepresentativeFullName { get; set; }
		public string RepresentativePhoneNumber { get; set; }
		public List<string> Courses { get; set; }
		public List<TimeDayViewModel> DayTime { get; set; }
	}
}
