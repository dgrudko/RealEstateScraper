using Assessment.Res.Core.Contracts.AgentAnalysis;
using Assessment.Res.Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment.Res.Infrastructure.Database.Repositories
{
    public class AgentAggregatedInfoRepository : IAgentAggregatedInfoRepository
    {
        private readonly RealEstateScraperDbContext _dbContext;

        public AgentAggregatedInfoRepository(RealEstateScraperDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<AgentAggregatedInfo>> CountTopAgentsAsync()
        {
            return await CountTopAgentsAsync(_dbContext.Offers);
        }

        public async Task<IEnumerable<AgentAggregatedInfo>> CountTopAgentsWithGardenAsync()
        {
            return await CountTopAgentsAsync(_dbContext.Offers.Where(x => x.WithGarden));
        }

        private async Task<IEnumerable<AgentAggregatedInfo>> CountTopAgentsAsync(IQueryable<OfferEntity> source)
        {
            return await source
                   .GroupBy(x => x.AgentId)
                   .OrderByDescending(x => x.Count())
                   .Take(10)
                   .Select(x =>
                       new AgentAggregatedInfo
                       {
                           Id = x.Key,
                           NumberOfProperties = x.Count()
                       })
                   .ToListAsync();
        }

        public async Task SaveTopAgentsAsync(IEnumerable<AgentAggregatedInfo> agentAggregatedInfos)
        {
            var entities = agentAggregatedInfos.Select(x =>
                new TopAgentsEntity 
                { 
                    AgentId = x.Id,
                    NumberOfProperties = x.NumberOfProperties
                }
            ).ToList();

            await _dbContext.Database.ExecuteSqlRawAsync("DELETE FROM [TopAgents]");
            await _dbContext.TopAgents.AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveTopAgentsWithGardenAsync(IEnumerable<AgentAggregatedInfo> agentAggregatedInfos)
        {
            var entities = agentAggregatedInfos.Select(x =>
                new TopAgentsWithGardenEntity
                {
                    AgentId = x.Id,
                    NumberOfProperties = x.NumberOfProperties
                }
            ).ToList();

            await _dbContext.Database.ExecuteSqlRawAsync("DELETE FROM [TopAgentsWithGarden]");
            await _dbContext.TopAgentsWithGarden.AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();
        }
    }
}
