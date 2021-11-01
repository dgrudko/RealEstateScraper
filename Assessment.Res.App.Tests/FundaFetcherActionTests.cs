using Assessment.Res.App.Actions;
using Assessment.Res.Application.Contracts.Fetchers;
using FakeItEasy;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace Assessment.Res.App.Tests
{
    [TestFixture]
    public class FundaFetcherActionTests
    {
        private IFundaFetcherUseCase _fundaFetcherUseCase;
        private FundaFetcherAction _fundaFetcherAction;


        [SetUp]
        public void SetUp()
        {
            _fundaFetcherUseCase = A.Fake<IFundaFetcherUseCase>();

            _fundaFetcherAction = new FundaFetcherAction(_fundaFetcherUseCase);
        }

        [Test]
        public async Task ActInnerAsync_FundaFetcherUseCaseActAsync_Happend()
        {
            var token = new CancellationTokenSource().Token;

            await _fundaFetcherAction.ActInnerAsync(token);

            A.CallTo(() => _fundaFetcherUseCase.ActAsync(token)).MustHaveHappenedOnceExactly();
        }
    }
}
