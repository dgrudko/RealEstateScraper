using System.Threading.Tasks;

namespace Assessment.Res.Core.Contracts.Agents
{
    public interface IAgentsService
    {
        Task<Agent> FindOrAddAsync(string vendorId, string name);
    }
}
