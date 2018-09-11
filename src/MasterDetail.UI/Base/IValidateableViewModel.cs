using System.ComponentModel;

namespace MasterDetail.UI.Base
{
    public interface IValidateableViewModel : INotifyPropertyChanged
    {
        IViewModelValidator Validator { get; }
    }
}