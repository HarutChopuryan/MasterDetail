using System.Collections.Generic;
using System.Collections.ObjectModel;
using MasterDetail.UI.Base;
using MasterDetail.UI.Base.Implementation;
using PropertyChanged;
using Xamarin.Forms;

namespace MasterDetail.UI.Main.Implementation
{
    [AddINotifyPropertyChangedInterface]
    public class UserViewModel : BaseBindableObject, IUserViewModel
    {
        public UserViewModel()
        {
            ImgItems = new ObservableCollection<string>();
            TakeCommand = new TakeCommand(this);
            PickCommand = new PickCommand(this);
            AddCommand = new AddCommand(this);
        }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public ImageSource ImageSource { get; set; } = "avatar.jpg";

        public IAsyncCommand TakeCommand { get; set; }

        public IAsyncCommand PickCommand { get; set; }

        public IList<string> ImgItems { get; set; }

        public IAsyncCommand AddCommand { get; set; }
    }
}