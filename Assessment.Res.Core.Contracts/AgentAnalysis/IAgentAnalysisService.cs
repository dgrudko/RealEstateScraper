using System.Threading.Tasks;

namespace Assessment.Res.Core.Contracts.Offers
{
    public interface IAgentAnalysisService
    {
        Task CountTopAgentsAsync();
    }
}
