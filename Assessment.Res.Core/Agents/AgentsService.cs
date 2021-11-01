using Assessment.Res.Core.Contracts.Agents;
using System.Threading.Tasks;

namespace Assessment.Res.Core.Agents
{
    public class AgentsService: IAgentsService
    {
        private readonly IAgentsRepository _agentsRepository;

        public AgentsService(IAgentsRepository agentsRepository)
        {
            _agentsRepository = agentsRepository;
        }

        public async Task<Agent> FindOrAddAsync(string vendorId, string name)
        {
            var agent = await _agentsRepository.GetByVendorIdAsync(vendorId);

            if (agent == null)
                agent = await _agentsRepository.SaveAsync(vendorId, name);

            return agent;
        }
    }
}
