using MasterDetail.UI.Base;
using MasterDetail.UI.Base.Implementation;
using PropertyChanged;
using Xamarin.Forms;

namespace MasterDetail.UI.Main.Implementation
{
    [AddINotifyPropertyChangedInterface]
    public class SelectedItemDetailsViewModel : BaseBindableObject, ISelectedItemDetailsViewModel
    {
        public SelectedItemDetailsViewModel()
        {
            ShowTappedImgCommand = new ShowTappedImgCommand(this);
        }

        public string DbName { get; set; }

        public string Name { get;  set; }

        public ImageSource ImageSource { get; set; }

        public IAsyncCommand ShowTappedImgCommand { get; set; }
    }
}