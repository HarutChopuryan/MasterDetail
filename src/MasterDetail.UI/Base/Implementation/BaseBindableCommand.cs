using System;
using PropertyChanged;

namespace MasterDetail.UI.Base.Implementation
{
    [AddINotifyPropertyChangedInterface]
    public abstract class BaseBindableCommand : BaseBindableObject, IBindableCommand
    {
        private bool _canExecute;

        protected BaseBindableCommand(bool canExecute = true)
        {
            _canExecute = canExecute;
            IsExecutable = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _canExecute;
        }

        public abstract void Execute(object parameter = null);

        public bool IsExecutable { get; private set; }

        protected void SetCanExecute(bool canExecute)
        {
            _canExecute = IsExecutable = canExecute;
            var canExecuteChanged = CanExecuteChanged;
            if (canExecuteChanged == null) return;
            var empty = EventArgs.Empty;
            canExecuteChanged(this, empty);
        }
    }
}