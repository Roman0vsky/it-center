
using System.ComponentModel.DataAnnotations;

namespace ITCenterBack.Models
{
	public class Square
	{
		[Key]
		public long Id { get; set; }
		public string? Image { get; set; }
		public string? Title { get; set; }
		public string? TextPreview { get; set; }
		public string? Content { get; set; }
	}
}
