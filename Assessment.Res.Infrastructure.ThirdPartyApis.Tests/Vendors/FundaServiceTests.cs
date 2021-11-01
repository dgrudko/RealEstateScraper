using Assessment.Res.Core.Contracts.Funda;
using Assessment.Res.Infrastructure.ThirdPartyApis.Vendors;
using FakeItEasy;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment.Res.Infrastructure.ThirdPartyApis.Tests.Vendors
{
    [TestFixture]
    public class FundaServiceTests
    {
        private IFundaConnector _fundaConnector;
        private FundaService _fundaService;

        [SetUp]
        public void SetUp()
        {
            _fundaConnector = A.Fake<IFundaConnector>();

            _fundaService = new FundaService(_fundaConnector);
        }

        [Test]
        public async Task GetOffersAsync_FundaConnectorGetOffersAsync_Happend()
        {
            var fundaResponse = new FundaGetOffersResponse
            {
                TotaalAantalObjecten = 10,
                Paging = new FundaPaging { AantalPaginas = 5 },
                Objects = new List<FundaObject>()
            };
            A.CallTo(() => _fundaConnector.GetOffersAsync(A<int>.Ignored, A<bool>.Ignored))
                .Returns(Task.FromResult(fundaResponse));

            var request = new GetOffersRequest(1, true);

            await _fundaService.GetOffersAsync(request);

            A.CallTo(() => _fundaConnector.GetOffersAsync(1, true)).MustHaveHappenedOnceExactly();
        }

        [Test]
        public async Task GetOffersAsync_NumberOfPages_Correct()
        {
            var fundaResponse = new FundaGetOffersResponse
            {
                TotaalAantalObjecten = 10,
                Paging = new FundaPaging { AantalPaginas = 5 },
                Objects = new List<FundaObject>()
            };
            A.CallTo(() => _fundaConnector.GetOffersAsync(A<int>.Ignored, A<bool>.Ignored))
                .Returns(Task.FromResult(fundaResponse));

            var result = await _fundaService.GetOffersAsync(new GetOffersRequest(1, true));

            Assert.AreEqual(fundaResponse.TotaalAantalObjecten, result.TotalNumber);
            Assert.AreEqual(fundaResponse.Paging.AantalPaginas, result.NumberOfPages);
        }

        [Test]
        public async Task GetOffersAsync_OffersMap_Correct()
        {
            var fundaResponse = new FundaGetOffersResponse
            {
                TotaalAantalObjecten = 10,
                Paging = new FundaPaging { AantalPaginas = 5 },
                Objects = new List<FundaObject>
                {
                    new FundaObject {

                        Id = new System.Guid(),
                        MakelaarId = 1,
                        Adres = "adres",
                        MakelaarNaam = "naam",
                        URL = "url",
                    },
                }
            };
            A.CallTo(() => _fundaConnector.GetOffersAsync(A<int>.Ignored, A<bool>.Ignored))
                .Returns(Task.FromResult(fundaResponse));

            var result = await _fundaService.GetOffersAsync(new GetOffersRequest(1, true));

            Assert.AreEqual(fundaResponse.Objects.Count(), result.Offers.Count());
            Assert.AreEqual(fundaResponse.Objects.First().MakelaarId, result.Offers.First().AgentVendorId);
        }
    }
}
