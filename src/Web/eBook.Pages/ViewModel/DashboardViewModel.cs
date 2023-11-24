namespace eBook.Pages.ViewModel
{
    public class DashboardViewModel
    {
        public DashboardViewModel()
        {
            CardWidgetViewModels = new List<CardWidgetViewModel>();
        }

        public List<CardWidgetViewModel> CardWidgetViewModels { get; set; }
    }
}
