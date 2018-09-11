using System.Collections.Generic;
using PropertyChanged;

namespace MasterDetail.UI.Base.Implementation
{
    [AddINotifyPropertyChangedInterface]
    internal class PickerViewModel : BaseBindableObject, IPickerViewModel
    {
        public List<string> PickerItems { get; set; }

        public IViewModelValidator Validator { get; }
    }
}