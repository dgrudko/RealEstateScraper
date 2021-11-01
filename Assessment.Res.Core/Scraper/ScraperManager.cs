using Assessment.Res.Core.Contracts.Agents;
using Assessment.Res.Core.Contracts.Funda;
using Assessment.Res.Core.Contracts.Offers;
using Assessment.Res.Core.Contracts.Scraper;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Assessment.Res.Core.Scraper
{
    public class ScraperManager: IScraperManager
    {
        private readonly IFundaService _fundaService;
        private readonly IAgentsService _agentsService;
        private readonly IOffersRepository _offersRepository;

        public ScraperManager(
            IFundaService fundaService, 
            IAgentsService agentsService, 
            IOffersRepository offersRepository)
        {
            _fundaService = fundaService;
            _agentsService = agentsService;
            _offersRepository = offersRepository;
        }

        public async Task SrapAsync(CancellationToken cancellationToken, bool withGrden)
        {
            var currentPage = 1;
            while (cancellationToken.IsCancellationRequested == false)
            {
                var request = new GetOffersRequest(currentPage, withGrden);
                var result = await _fundaService.GetOffersAsync(request);

                var offersByAgent = result.Offers.GroupBy(x => x.AgentVendorId);

                foreach (var offersGroup in offersByAgent)
                {
                    var agent = await _agentsService.FindOrAddAsync(offersGroup.Key.ToString(), offersGroup.FirstOrDefault().AgentName);

                    foreach (var offer in offersGroup)
                    {
                        offer.AgentId = agent.Id;
                        await _offersRepository.SaveAsync(offer);
                    }
                }

                if (currentPage >= result.NumberOfPages)
                    return;

                currentPage++;
            }
        }
    }
}
