using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assessment.Res.Core.Contracts.AgentAnalysis
{
    public interface IAgentAggregatedInfoRepository
    {
        Task<IEnumerable<AgentAggregatedInfo>> CountTopAgentsAsync();
        Task<IEnumerable<AgentAggregatedInfo>> CountTopAgentsWithGardenAsync();
        Task SaveTopAgentsAsync(IEnumerable<AgentAggregatedInfo> agentAggregatedInfos);
        Task SaveTopAgentsWithGardenAsync(IEnumerable<AgentAggregatedInfo> agentAggregatedInfos);
    }
}
