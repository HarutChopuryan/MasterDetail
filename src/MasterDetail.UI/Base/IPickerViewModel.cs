using System.Collections.Generic;
using System.ComponentModel;

namespace MasterDetail.UI.Base
{
    internal interface IPickerViewModel : INotifyPropertyChanged, IValidateableViewModel
    {
        List<string> PickerItems { get; set; }
    }
}