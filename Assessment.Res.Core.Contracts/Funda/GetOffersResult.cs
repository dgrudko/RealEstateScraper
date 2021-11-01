using System.Collections.Generic;

namespace Assessment.Res.Core.Contracts.Funda
{
    public class GetOffersResult
    {
        public int NumberOfPages { get; }
        public int TotalNumber { get; }
        public IEnumerable<PropertyOffer> Offers { get; }

        public GetOffersResult(int numberOfPages, int totalNumber, IEnumerable<PropertyOffer> offers)
        {
            NumberOfPages = numberOfPages;
            TotalNumber = totalNumber;
            Offers = offers;
        }
    }
}
