namespace DvdShop.Domain.Models
{
    public class Dvd
    {
        public Dvd(int movieId)
        {
            MovieId = movieId;
            User = null;
            Condition = 10;
        }
        public int MovieId { get; }
        public string User { get; set; }
        public int Condition { get; set; }
        public bool Available { get; set; }
    }
}