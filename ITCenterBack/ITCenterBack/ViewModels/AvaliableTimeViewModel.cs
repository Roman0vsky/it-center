﻿using ITCenterBack.Models;

namespace ITCenterBack.ViewModels
{
	public class AvaliableTimeViewModel
	{
		public long Id { get; set; }
		public List<AvaliableTime> AvaliableTimes { get; set; }
		public List<TimeViewModel> Time { get; set; }
	}
}
