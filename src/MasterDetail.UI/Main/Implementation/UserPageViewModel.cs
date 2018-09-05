using System.Threading;
using MasterDetail.UI.Base;
using MasterDetail.UI.Base.Implementation;
using PropertyChanged;
using Xamarin.Forms;


namespace MasterDetail.UI.Main.Implementation
{
    [AddINotifyPropertyChangedInterface]
    public class UserPageViewModel : BaseBindableObject, IUserPageViewModel
    {
        public UserPageViewModel()
        {
            TakeCommand = new TakeCommand(this);
            PickCommand = new PickCommand(this);
        }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public ImageSource ImageSource { get; set; } = ImageSource.FromFile("avatar.jpg");

        public IAsyncCommand TakeCommand { get; set; }

        public IAsyncCommand PickCommand { get; set; }
    }
}