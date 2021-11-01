using Assessment.Res.Application.Contracts.Fetchers;
using Assessment.Res.Core.Contracts.Offers;
using Assessment.Res.Core.Contracts.Scraper;
using System.Threading;
using System.Threading.Tasks;

namespace Assessment.Res.Application.Fetchers
{
    public class FundaFetcherUseCase: IFundaFetcherUseCase
    {
        private readonly IScraperManager _scraperManager;
        private readonly IAgentAnalysisService _agentAnalysisService;

        public FundaFetcherUseCase(IScraperManager scraperManager, IAgentAnalysisService agentAnalysisService)
        {
            _scraperManager = scraperManager;
            _agentAnalysisService = agentAnalysisService;
        }

        public async Task ActAsync(CancellationToken cancellationToken)
        {
            await _scraperManager.SrapAsync(cancellationToken, withGrden: false);
            await _scraperManager.SrapAsync(cancellationToken, withGrden: true);

            await _agentAnalysisService.CountTopAgentsAsync();
        }
    }
}
