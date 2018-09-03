using MasterDetail.UI.Base.Implementation;
using PropertyChanged;
using Xamarin.Forms;


namespace MasterDetail.UI.Main.Implementation
{
    [AddINotifyPropertyChangedInterface]
    public class UserPageViewModel : BaseBindableObject, IUserPageViewModel
    {
        public ImageSource ImageSource { get; set; } = ImageSource.FromFile("avatar.jpg");
    }
}