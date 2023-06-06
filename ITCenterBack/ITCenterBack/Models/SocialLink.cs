using System.ComponentModel.DataAnnotations;

namespace ITCenterBack.Models
{
	public class SocialLink
	{
		[Key]
		public long Id { get; set; }
		public string Name { get; set; }
		public string Url { get; set; }
	}
}
