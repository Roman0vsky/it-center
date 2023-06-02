namespace ITCenterBack.ViewModels
{
    public class IndexViewModel
    {
        public HeaderViewModel Header { get; set; }
        public List<CourseViewModel> Courses { get; set; }
        public List<NewsViewModel> News { get; set; }
        public List<SliderImageViewModel> SliderImages { get; set; }
        public AboutUsViewModel AboutUs { get; set; }
        public InfoViewModel Info { get; set; }
    }
}
