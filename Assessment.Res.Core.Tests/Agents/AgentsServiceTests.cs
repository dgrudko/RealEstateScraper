using Assessment.Res.Core.Agents;
using Assessment.Res.Core.Contracts.Agents;
using FakeItEasy;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Assessment.Res.Core.Tests.Agents
{
    [TestFixture]
    public class AgentsServiceTests
    {
        private IAgentsRepository _agentsRepository;
        private AgentsService _agentsService;


        [SetUp]
        public void SetUp()
        {
            _agentsRepository = A.Fake<IAgentsRepository>();
            _agentsService = new AgentsService(_agentsRepository);
        }

        [Test]
        public async Task FindOrAddAsync_GetByVendorIdAsync_Happend()
        {
            await _agentsService.FindOrAddAsync("vendor", "name");

            A.CallTo(() => _agentsRepository.GetByVendorIdAsync("vendor")).MustHaveHappenedOnceExactly();
        }

        [Test]
        public async Task FindOrAddAsync_SaveAsync_Happend()
        {
            A.CallTo(() => _agentsRepository.GetByVendorIdAsync(A<string>.Ignored))
                .Returns(Task.FromResult(default(Agent)));

            await _agentsService.FindOrAddAsync("vendor", "name");

            A.CallTo(() => _agentsRepository.SaveAsync("vendor", "name")).MustHaveHappenedOnceExactly();
        }

        [Test]
        public async Task FindOrAddAsync_SaveAsync_NotHappened()
        {
            A.CallTo(() => _agentsRepository.GetByVendorIdAsync(A<string>.Ignored))
                .Returns(Task.FromResult(new Agent()));

            await _agentsService.FindOrAddAsync("vendor", "name");

            A.CallTo(() => _agentsRepository.SaveAsync(A<string>.Ignored, A<string>.Ignored))
                .MustNotHaveHappened();
        }
    }
}
