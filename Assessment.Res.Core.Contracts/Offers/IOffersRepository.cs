using System.Threading.Tasks;

namespace Assessment.Res.Core.Contracts.Offers
{
    public interface IOffersRepository
    {
        Task SaveAsync(PropertyOffer offer);
    }
}
