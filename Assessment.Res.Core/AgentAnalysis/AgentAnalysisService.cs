using Assessment.Res.Core.Contracts.AgentAnalysis;
using Assessment.Res.Core.Contracts.Offers;
using System.Threading.Tasks;

namespace Assessment.Res.Core.AgentAnalysis
{
    public class AgentAnalysisService : IAgentAnalysisService
    {
        private readonly IAgentAggregatedInfoRepository _agentAggregatedInfoRepository;

        public AgentAnalysisService(IAgentAggregatedInfoRepository agentAggregatedInfoRepository)
        {
            _agentAggregatedInfoRepository = agentAggregatedInfoRepository;
        }

        public async Task CountTopAgentsAsync()
        {
            var topAgents = await _agentAggregatedInfoRepository.CountTopAgentsAsync();
            await _agentAggregatedInfoRepository.SaveTopAgentsAsync(topAgents);

            var topAgentsWithGarden = await _agentAggregatedInfoRepository.CountTopAgentsWithGardenAsync();
            await _agentAggregatedInfoRepository.SaveTopAgentsWithGardenAsync(topAgentsWithGarden);
        }
    }
}
