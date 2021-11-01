using System.Threading.Tasks;

namespace Assessment.Res.Infrastructure.ThirdPartyApis.Vendors
{
    public interface IFundaConnector
    {
        Task<FundaGetOffersResponse> GetOffersAsync(int page, bool withGarden);
    }
}
