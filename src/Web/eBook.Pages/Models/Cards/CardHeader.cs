namespace eBook.Pages.Models.Cards
{
    public class CardHeader
    {
        public CardHeader()
        {
            CardTitle = new CardTitle();
            CardToolbar = new CardToolbar();
        }

        public CardTitle CardTitle { get; set; }
        public CardToolbar CardToolbar { get; set; }
    }
}
