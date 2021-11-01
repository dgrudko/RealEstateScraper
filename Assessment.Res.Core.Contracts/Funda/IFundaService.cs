using System.Threading.Tasks;

namespace Assessment.Res.Core.Contracts.Funda
{
    public interface IFundaService
    {
        Task<GetOffersResult> GetOffersAsync(GetOffersRequest getOffersRequest);
    }
}
