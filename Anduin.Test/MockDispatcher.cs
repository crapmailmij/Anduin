using MvvmCross.Base;
using MvvmCross.ViewModels;
using MvvmCross.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Anduin.Test
{
    public class MockDispatcher
    : MvxMainThreadDispatcher
    , IMvxViewDispatcher
    {
        public readonly List<MvxViewModelRequest> Requests = new List<MvxViewModelRequest>();
        public readonly List<MvxPresentationHint> Hints = new List<MvxPresentationHint>();

        public override bool IsOnMainThread => throw new NotImplementedException();

        bool IMvxMainThreadAsyncDispatcher.IsOnMainThread => throw new NotImplementedException();

        public bool RequestMainThreadAction(Action action)
        {
            action();
            return true;
        }

        public bool ShowViewModel(MvxViewModelRequest request)
        {
            Requests.Add(request);
            return true;
        }

        public bool ChangePresentation(MvxPresentationHint hint)
        {
            Hints.Add(hint);
            return true;
        }

        public override bool RequestMainThreadAction(Action action, bool maskExceptions = true)
        {
            throw new NotImplementedException();
        }

        Task<bool> IMvxViewDispatcher.ShowViewModel(MvxViewModelRequest request)
        {
            throw new NotImplementedException();
        }

        Task<bool> IMvxViewDispatcher.ChangePresentation(MvxPresentationHint hint)
        {
            throw new NotImplementedException();
        }


        Task IMvxMainThreadAsyncDispatcher.ExecuteOnMainThreadAsync(Action action, bool maskExceptions)
        {
            return Task.FromResult<object>(null);

        }

        public Task ExecuteOnMainThreadAsync(Func<Task> action, bool maskExceptions = true)
        {
            throw new NotImplementedException();
        }
    }
}
