using System.ComponentModel.DataAnnotations;

namespace ITCenterBack.Models
{
	public class Info
	{
		[Key]
		public long Id { get; set; }
		public string? SliderFirstText { get; set; }
		public string? SliderSecondText { get; set; }
        public string? SliderThirdText { get; set; }
        public string? NameOfTheCenter { get; set; }
		public string? HeaderLogo { get; set; }
		public string? FooterLogo { get; set; }
		public string? NameOfUniversity { get; set; }
		public string? AdressOfUniversity { get; set; }
		public string? PhoneNumber1 { get; set; }
		public string? PhoneNumber2 { get; set; }
		public string? Email { get; set; }
	}
}
