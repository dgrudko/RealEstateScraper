namespace Assessment.Res.Core.Contracts.Funda
{
    public class GetOffersRequest
    {
        public int Page { get; }
        public bool WithGarden { get; }

        public GetOffersRequest(int page, bool withGarden)
        {
            Page = page;
            WithGarden = withGarden;
        }
    }
}
