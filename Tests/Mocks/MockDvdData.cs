using System.Collections.Generic;
using DvdShop.Domain.Models;

namespace DvdShop.Tests.Mocks
{
    public class MockDvdData
    {
        public MockDvdData(Movie movie, IEnumerable<Dvd> dvds)
        {
            Movie = movie;
            Dvds = dvds;
        }

        public Movie Movie { get; }
        public IEnumerable<Dvd> Dvds { get; }
    }
}