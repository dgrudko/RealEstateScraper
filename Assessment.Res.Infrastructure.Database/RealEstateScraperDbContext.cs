using Assessment.Res.Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Assessment.Res.Infrastructure.Database
{
    public class RealEstateScraperDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=RES-1;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public virtual DbSet<AgentEntity> Agents { get; set; }
        public virtual DbSet<OfferEntity> Offers { get; set; }
        public virtual DbSet<TopAgentsEntity> TopAgents { get; set; }
        public virtual DbSet<TopAgentsWithGardenEntity> TopAgentsWithGarden { get; set; }

    }
}
