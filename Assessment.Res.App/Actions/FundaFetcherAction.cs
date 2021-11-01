using Assessment.Res.Application.Contracts.Fetchers;
using System.Threading;
using System.Threading.Tasks;

namespace Assessment.Res.App.Actions
{
    public class FundaFetcherAction : AsyncActionBase
    {
        private readonly IFundaFetcherUseCase _fundaFetcherUseCase;

        public FundaFetcherAction(IFundaFetcherUseCase fundaFetcherUseCase)
        {
            _fundaFetcherUseCase = fundaFetcherUseCase;
        }

        public override async Task ActInnerAsync(CancellationToken cancellationToken)
        {
            await _fundaFetcherUseCase.ActAsync(cancellationToken);
        }
    }
}
