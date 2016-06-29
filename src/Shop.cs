using DvdShop.Domain;
using System.Collections.Generic;
using System.Linq;
using DvdShop.Models.View;
namespace DvdShop
{
    public class Shop
    {
        private readonly IMovieDatabase _db;
        public Shop(IMovieDatabase db)
        {
            _db = db;
        }

        public IEnumerable<DvdSummary> GetAvailableMovies()
        {
            return Enumerable.Empty<DvdSummary>();
        }
    }    
}
