namespace DvdShop.Domain.Models
{
    public class Movie
    {
        public Movie(string title, decimal price, string imdbId)
        {
            Title = title;
            Price = price;
            ImdbId = imdbId;
        }

        public string Title { get; }
        public decimal Price { get; }
        public string ImdbId { get; }
    }
}