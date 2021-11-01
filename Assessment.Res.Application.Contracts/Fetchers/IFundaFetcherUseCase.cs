using System.Threading;
using System.Threading.Tasks;

namespace Assessment.Res.Application.Contracts.Fetchers
{
    public interface IFundaFetcherUseCase
    {
        Task ActAsync(CancellationToken cancellationToken);
    }
}
