using Assessment.Res.Core.Contracts.Agents;
using Assessment.Res.Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment.Res.Infrastructure.Database.Repositories
{
    public class AgentsRepository : IAgentsRepository
    {
        private readonly RealEstateScraperDbContext _dbContext;

        public AgentsRepository(RealEstateScraperDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Agent> GetByVendorIdAsync(string vendorId)
        {
            return await _dbContext.Agents.Select(x => 
                new Agent {
                    Id = x.Id,
                    Name = x.Name, 
                    VendorId = x.VendorId 
                }
            ).FirstOrDefaultAsync(x => x.VendorId == vendorId);
        }

        public async Task<Agent> SaveAsync(string vendorId, string name)
        {
            var entity = new AgentEntity
            {
                VendorId = vendorId,
                Name = name
            };

            await _dbContext.Agents.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return new Agent
            {
                Id = entity.Id,
                Name = entity.Name,
                VendorId = entity.VendorId
            };
        }
    }
}
