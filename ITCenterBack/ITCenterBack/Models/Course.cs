﻿using System.ComponentModel.DataAnnotations;

namespace ITCenterBack.Models
{
    public class Course
    {
        [Key]
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Age { get; set; }
        public string? Description { get; set; }
        public string? Requirements { get; set; }
        public string? Image { get; set; }
    }
}
