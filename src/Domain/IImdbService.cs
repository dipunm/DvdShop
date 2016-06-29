using System;

namespace DvdShop.Domain
{
    public interface IImdbService
    {
        Uri FetchThumbnailImage(string imdbId);
    }
}