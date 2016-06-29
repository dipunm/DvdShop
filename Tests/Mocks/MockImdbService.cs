using System;
using System.Collections.Generic;

namespace DvdShop.Tests.Mocks
{
    public class MockImdbService : DvdShop.Domain.IImdbService
    {
        private Dictionary<string, Uri> _imageUrls {get;} = new Dictionary<string, Uri>();
        public Uri FetchThumbnailImage(string imdbId)
        {
            if(_imageUrls.ContainsKey(imdbId))
                return _imageUrls[imdbId];
            return null;
        }

        public void SetImageUrl(string imdbId, Uri uri)
        {
            if(_imageUrls.ContainsKey(imdbId))
                _imageUrls[imdbId] = uri;
            else
                _imageUrls.Add(imdbId, uri);
        }
    }
}