using System;

namespace ITCenterBack.ViewModels
{
    public class NewsViewModel
    {
        public DateTime PublicationDate { get; set; }
        public long Id { get; set; }
        public string Title { get; set; }
        public string? Text { get; set; }
        public string? ShortText
        {
            get { return ShortText; }
            set => ShortText = string.Concat(Text.AsSpan(0, 60), "...");
        }
        public string? Image { get; set; }
    }
}
