namespace eBook.Pages.Models.Cards
{
    public class CardBody
    {
        public CardBody()
        {
            CardBodyInfos = new List<CardBodyInfo>();
        }

        public List<CardBodyInfo> CardBodyInfos { get; set; }
    }
}
