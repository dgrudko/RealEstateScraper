using Assessment.Res.App.Actions;
using System.Collections.Generic;

namespace Assessment.Res.App
{
    public class ResWindowsService
    {
        private readonly List<IAction> _actions;

        public ResWindowsService(FundaFetcherAction fundaFetcherAction)
        {
            _actions = new List<IAction>(){ fundaFetcherAction };
        }

        public void Start()
        {
            _actions.ForEach(worker => worker.Start());
        }

        public void Stop()
        {
            _actions.ForEach(worker => worker.Stop());
        }
    }
}
