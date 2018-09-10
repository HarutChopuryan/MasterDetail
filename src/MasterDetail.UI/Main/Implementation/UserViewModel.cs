using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
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
            ImgDetailsCommand = new ImgDetailsCommand(this);
            ImgItems = new ObservableCollection<UserImagesViewModel>();
            ImgDetails = new SelectedItemDetailsViewModel();
            TakeCommand = new TakeCommand(this);
            PickCommand = new PickCommand(this);
            AddCommand = new AddCommand(this);
        }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public ImageSource AccountImageSource { get; set; } = "avatar.jpg";

        public IAsyncCommand TakeCommand { get; set; }

        public IAsyncCommand PickCommand { get; set; }

        public IList<UserImagesViewModel> ImgItems { get; set; }

        public IAsyncCommand AddCommand { get; set; }

        public ISelectedItemDetailsViewModel ImgDetails { get; set; }

        public IAsyncCommand ImgDetailsCommand { get; set; }
    }
}