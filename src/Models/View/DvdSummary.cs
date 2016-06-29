using System;

namespace DvdShop.Models.View
{
    public class DvdSummary{
        public int DvdId { get; }
        public string Title { get; }
        public double RRPrice { get; }
        public Uri ImageUrl { get; }
    }   
}