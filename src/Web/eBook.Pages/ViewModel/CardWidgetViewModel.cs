using eBook.Pages.Models.Cards;

namespace eBook.Pages.ViewModel
{
    public class CardWidgetViewModel
    {
        public CardHeader CardHeader { get; set; } = new();
        public CardBody CardBody { get; set; } = new();
    }
}
