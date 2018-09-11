using MasterDetail.UI.Base.Implementation;
using PropertyChanged;
using Xamarin.Forms;

namespace MasterDetail.UI.Main.Implementation
{
    [AddINotifyPropertyChangedInterface]
    public class UserImagesViewModel : BaseBindableObject, IUserImagesViewModel
    {
        public ImageSource ImageSource { get; set; }

        public string ImageName { get; set; }
    }
}