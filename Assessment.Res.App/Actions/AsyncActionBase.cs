using System.Threading;
using System.Threading.Tasks;

namespace Assessment.Res.App.Actions
{
    public abstract class AsyncActionBase : IAction
    {
        protected CancellationTokenSource TokenSource = new CancellationTokenSource();

        public void Start()
        {
            Task.Factory.StartNew(async () => await ActAsync(TokenSource.Token), TaskCreationOptions.LongRunning);
        }

        public async Task ActAsync(CancellationToken cancellationToken)
        {
            await ActInnerAsync(cancellationToken);
        }

        public abstract Task ActInnerAsync(CancellationToken cancellationToken);

        public void Stop()
        {
            TokenSource.Cancel();
        }
    }
}
