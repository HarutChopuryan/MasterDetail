using MasterDetail.UI.Base.Implementation;
using PropertyChanged;

namespace MasterDetail.UI.Main.Implementation
{
    [AddINotifyPropertyChangedInterface]
    public class MasterPageViewModel : BaseBindableObject, IMasterPageViewModel
    {
        public string ImageSource { get; set; }
    }
}