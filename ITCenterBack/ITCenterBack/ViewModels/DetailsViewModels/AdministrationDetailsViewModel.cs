using ITCenterBack.ViewModels.BasicViewModels;

namespace ITCenterBack.ViewModels.DetailsViewModels
{
    public class AdministrationDetailsViewModel
    {
        public HeaderViewModel Header { get; set; }
        public List<AdministrationViewModel> Administration { get; set; }
        public FooterViewModel Footer { get; set; }
    }
}
