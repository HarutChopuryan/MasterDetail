using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PropertyChanged;

namespace MasterDetail.UI.Base.Implementation
{
    [AddINotifyPropertyChangedInterface]
    public abstract class AsyncCommand : BaseBindableCommand, IAsyncCommand
    {
        public AsyncCommand() : base(true)
        {
        }

        public AsyncCommand(bool canExecute) : base(canExecute)
        {
        }

        public override async void Execute(object parameter = null)
        {
            await ExecuteAsync(parameter);
        }
        
        public bool IsBusy { get; private set; }
        public string FailureMessage { get; protected set; }
        public bool IsSuccessful { get; private set; }
        
        public virtual async Task ExecuteAsync(object parameter = null, CancellationToken token = default(CancellationToken))
        {
            if (IsBusy) return;
            //Reset the state of the command
            IsBusy = true;
            IsSuccessful = false;
            FailureMessage = "";
            try
            {
                IsSuccessful = await ExecuteCoreAsync(parameter, token);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
            finally
            {
                //At the end set that execution has finished
                IsBusy = false;
            }
        }
        
        protected abstract Task<bool> ExecuteCoreAsync(object parameter = null, CancellationToken token = default(CancellationToken));
        
        protected virtual void HandleException(Exception exception)
        {
            FailureMessage = exception.Message;
            Debug.WriteLine(exception);
        }
    }
}