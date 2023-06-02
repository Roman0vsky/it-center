using System.ComponentModel.DataAnnotations;

namespace ITCenterBack.Models
{
	public class Info
	{
		[Key]
		public long Id { get; set; }
		public string SliderBigText { get; set; }
		public string SliderSmallText { get; set; }
		public string NameOfTheCenter { get; set; }
		public string HeaderLogo { get; set; }
		public string FooterLogo { get; set; }
		public string NameOfUniversity { get; set; }
		public string AdressOfUniversity { get; set; }
	}
}
