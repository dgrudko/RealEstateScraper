using Assessment.Res.Application.Fetchers;
using Assessment.Res.Core.Contracts.Offers;
using Assessment.Res.Core.Contracts.Scraper;
using FakeItEasy;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace Assessment.Res.Application.Tests.Fetchers
{
    [TestFixture]
    public class FundaFetcherUseCaseTests
    {
        private IScraperManager _scraperManager;
        private IAgentAnalysisService _agentAnalysisService;
        private FundaFetcherUseCase _useCase;

        [SetUp]
        public void SetUp()
        {
            _scraperManager = A.Fake<IScraperManager>();
            _agentAnalysisService = A.Fake<IAgentAnalysisService>();

            _useCase = new FundaFetcherUseCase(_scraperManager, _agentAnalysisService);
        }

        [Test]
        public async Task ActAsync_CountTopAgentsAsync_Happend()
        {
            await _useCase.ActAsync(new CancellationTokenSource().Token);

            A.CallTo(() => _agentAnalysisService.CountTopAgentsAsync()).MustHaveHappenedOnceExactly();
        }

        [Test]
        public async Task ActAsync_SrapAsync_Happend()
        {
            var token = new CancellationTokenSource().Token;

            await _useCase.ActAsync(token);

            A.CallTo(() => _scraperManager.SrapAsync(token, true)).MustHaveHappenedOnceExactly();
            A.CallTo(() => _scraperManager.SrapAsync(token, false)).MustHaveHappenedOnceExactly();
        }
    }
}
