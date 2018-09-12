using MasterDetail.UI.Base.Implementation;
using PropertyChanged;
using Xamarin.Forms;

namespace MasterDetail.UI.Main.Implementation
{
    [AddINotifyPropertyChangedInterface]
    public class SelectedItemDetailsViewModel : BaseBindableObject, ISelectedItemDetailsViewModel
    {
        public string Name { get;  set; }

        public ImageSource ImageSource { get; set; }
    }
}