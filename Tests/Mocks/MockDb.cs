using System;
using System.Linq;
using System.Collections.Generic;
using DvdShop.Domain;
using DvdShop.Domain.Models;

namespace DvdShop.Tests.Mocks
{
    public class MockDb : IMovieDatabase
    {
        private IEnumerable<Movie> _movies;
        public MockDb()
        {
            _movies = new List<Movie>()
            {
                new Movie("Tango & Cash", 4.99m, "MS9E0"),
                new Movie("Rocky", 4.99m, "DS0B3"),
                new Movie("8 Mile", 4.99m, "U8SF8")
            };

            Dvds = new DvdCollection(_movies.SelectMany(m => {
                return Enumerable.Repeat(new Dvd(m.Id), 3);
            }));
        }

        public DvdCollection Dvds { get; private set; }
        public void Repopulate(IEnumerable<MockDvdData> data)
        {
            _movies = new List<Movie>(data.Select(d => d.Movie));
            Dvds = new DvdCollection(data.SelectMany(d => d.Dvds));
        }
    }

    public class DvdCollection : List<Dvd> 
    {
        public DvdCollection(IEnumerable<Dvd> dvds) : base(dvds)
        { }

        public DvdCollection ByMovie(int movieId)
        {
            return new DvdCollection(this.Where(d => d.MovieId == movieId));
        }

        public void Update(Action<Dvd> changes)
        {
            this.ForEach(changes);
        }

        public void Update(Action<Dvd> changes, int limit)
        {
            this.Take(limit).ToList().ForEach(changes);
        }
    }
}