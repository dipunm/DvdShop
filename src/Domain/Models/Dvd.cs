namespace DvdShop.Domain.Models
{
    public class Dvd
    {
        public Dvd(string imdbId)
        {
            ImdbId = imdbId;
            User = null;
            Condition = 10;
        }
        public string ImdbId { get; }
        public string User { get; set; }
        public int Condition { get; set; }
    }
}