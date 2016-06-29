using NUnit.Framework;
using DvdShop.Tests.Mocks;
using System;
using DvdShop.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using Shouldly;

namespace DvdShop.Tests
{
    [TestFixture]
    public class ShopTests
    {
        private MockDb _db;
        private Shop _shop;
        private MockImdbService _imdb;
        [SetUp]
        public void Setup()
        {
            //By default, MockDb has 3 dvds, all available.
            _db = new MockDb();
            _shop = new Shop(_db);
            _imdb = new MockImdbService();
        }

        [Test]
        public void GetAvailableMovies_ShouldReturnDataFromDatabase()
        {
            var DummyData = MovieWithDvds("Movie 1", 3)
                .Concat(MovieWithDvds("Movie 2", 3))
                .Concat(MovieWithDvds("Movie 3", 3));
            _db.Repopulate(DummyData);

            var movies = _shop.GetAvailableMovies();

            movies.Count().ShouldBe(3);
        }

        [Test]
        public void GetAvailableMovies_WhenAllDvdsForAMovieIsUnavailable_ShouldNotIncludeMovieInResult()
        {
            _db.Dvds.ByMovie(2)
                .Update(dvd => dvd.Available = false);

            var movies = _shop.GetAvailableMovies();

            movies.Count().ShouldBe(2);
            movies.ShouldNotContain(m => m.DvdId == 2);
        }

        [Test]
        public void GetAvailableMovies_WhenSomeDvdsForAMovieIsUnavailable_ShouldStillIncludeMovieInResult()
        {
            _db.Dvds.ByMovie(2)
                .Update(dvd => dvd.Available = false, limit: 1);

            var movies = _shop.GetAvailableMovies();

            movies.Count().ShouldBe(3);
        }

        [Test]
        public void GetAvailableMovies_EachMovie_ShouldContainMovieTitle()
        {
            var DummyData = MovieWithDvds(new Movie("Movie 1", 5.99m, "U8HS8"), 3);
            _db.Repopulate(DummyData);

            var movies = _shop.GetAvailableMovies();

            movies.Single().Title.ShouldBe("Movie 1");
        }
        
        [Test]
        public void GetAvailableMovies_EachMovie_ShouldContainMovieRRPrice()
        {
            var DummyData = MovieWithDvds(new Movie("Movie 1", 5.99m, "U8HS8"), 3);
            _db.Repopulate(DummyData);

            var movies = _shop.GetAvailableMovies();

            movies.Single().RRPrice.ShouldBe(5.99);
        }

        [Test]
        public void GetAvailableMovies_EachMovie_ShouldContainImageUrlFromIMDB()
        {
            var DummyData = MovieWithDvds(new Movie("Movie 1", 5.99m, "U8HS8"), 3);
            _db.Repopulate(DummyData);

            _imdb.SetImageUrl("U8HS8", new Uri("http://imdburl.com"));

            var movies = _shop.GetAvailableMovies();

            movies.Single().ImageUrl.ShouldBe(new Uri("http://imdburl.com"));
        }

        private IEnumerable<MockDvdData> MovieWithDvds(Movie movie, int nDvds)
        {
            return new []{
                new MockDvdData(movie, System.Linq.Enumerable.Repeat(
                    new Dvd(movie.Id), nDvds))};
        }
        
        private IEnumerable<MockDvdData> MovieWithDvds(string movieTitle, int nDvds)
        {
            return MovieWithDvds(new Movie(movieTitle, 9.99m, "12345"), nDvds);
        }
    }
}