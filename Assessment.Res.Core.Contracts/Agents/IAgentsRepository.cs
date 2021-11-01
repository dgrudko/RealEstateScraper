using System.Threading.Tasks;

namespace Assessment.Res.Core.Contracts.Agents
{
    public interface IAgentsRepository
    {
        Task<Agent> GetByVendorIdAsync(string vendorId);
        Task<Agent> SaveAsync(string vendorId, string name);
    }
}
