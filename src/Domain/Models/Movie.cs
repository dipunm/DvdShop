namespace DvdShop.Domain.Models
{
    public class Movie
    {
        public Movie(string title, decimal price, string imdbId)
        {
            Id = 0;
            Title = title;
            Price = price;
            ImdbId = imdbId;
        }

        public int Id { get; }
        public string Title { get; }
        public decimal Price { get; }
        public string ImdbId { get; }
    }
}