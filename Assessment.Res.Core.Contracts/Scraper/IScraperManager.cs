using System.Threading;
using System.Threading.Tasks;

namespace Assessment.Res.Core.Contracts.Scraper
{
    public interface IScraperManager
    {
        Task SrapAsync(CancellationToken cancellationToken, bool withGrden);
    }
}
