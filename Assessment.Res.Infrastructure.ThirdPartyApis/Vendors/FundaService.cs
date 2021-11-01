using Assessment.Res.Core.Contracts;
using Assessment.Res.Core.Contracts.Funda;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment.Res.Infrastructure.ThirdPartyApis.Vendors
{
    public class FundaService: IFundaService
    {
        private readonly IFundaConnector _connector;

        public FundaService(IFundaConnector connector)
        {
            _connector = connector;
        }

        public async Task<GetOffersResult> GetOffersAsync(GetOffersRequest getOffersRequest)
        {
            var response = await _connector.GetOffersAsync(getOffersRequest.Page, getOffersRequest.WithGarden);

            var offers = response.Objects.Select(x => 
                new PropertyOffer
                {
                    VendorId = x.Id.ToString(),
                    AgentVendorId = x.MakelaarId,
                    AgentName = x.MakelaarNaam,
                    Name = x.Adres,
                    Url = x.URL,
                    WithGarden = getOffersRequest.WithGarden
                }
            ).ToList();

            return new GetOffersResult(response.Paging.AantalPaginas, response.TotaalAantalObjecten, offers);
        }
    }
}
