using System.ComponentModel;
using System.Windows.Input;

namespace MasterDetail.UI.Base
{
    public interface IBindableCommand : ICommand, INotifyPropertyChanged
    {
        bool IsExecutable { get; }
    }
}