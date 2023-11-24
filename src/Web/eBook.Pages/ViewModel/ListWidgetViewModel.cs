using eBook.Pages.Models;

namespace eBook.Pages.ViewModel
{
    public class ListWidgetViewModel
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }

        public List<ListDetail>? ListDetails { get; set; }
    }
}
