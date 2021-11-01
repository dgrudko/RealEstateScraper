using Assessment.Res.Core.Contracts;
using Assessment.Res.Core.Contracts.Offers;
using Assessment.Res.Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Assessment.Res.Infrastructure.Database.Repositories
{
    public class OffersRepository : IOffersRepository
    {
        private readonly RealEstateScraperDbContext _dbContext;

        public OffersRepository(RealEstateScraperDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveAsync(PropertyOffer offer)
        {
            var entity = await _dbContext.Offers.FirstOrDefaultAsync(x => x.VendorId == offer.VendorId);

            bool exists = entity != null;
            entity ??= new OfferEntity();
            Map(offer, entity);

            if (exists)
                _dbContext.Offers.Update(entity);
            else
                await _dbContext.Offers.AddAsync(entity);

            await _dbContext.SaveChangesAsync();
        }

        private void Map(PropertyOffer offer, OfferEntity offerEntity)
        {
            offerEntity.VendorId = offer.VendorId;
            offerEntity.AgentId = offer.AgentId;
            offerEntity.Name = offer.Name;
            offerEntity.Url = offer.Url;
            offerEntity.WithGarden = offer.WithGarden;
        }
    }
}
