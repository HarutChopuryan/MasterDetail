using System.Collections.Generic;
using System.Collections.ObjectModel;
using MasterDetail.UI.Base;
using MasterDetail.UI.Base.Implementation;
using MasterDetail.UI.Validators;
using PropertyChanged;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MasterDetail.UI.Main.Implementation
{
    [AddINotifyPropertyChangedInterface]
    public class UserViewModel : BaseBindableObject, IUserViewModel
    {
        public UserViewModel()
        {
            ImgItems = new ObservableCollection<UserImagesViewModel>();
            ImgDetails = new SelectedItemDetailsViewModel();
            TakeCommand = new TakeCommand(this);
            PickCommand = new PickCommand(this);
            AddCommand = new AddCommand(this);
            Validator = new MainValidator(this);
            LocateCommand = new LocateCommand(this);
        }

        public IAsyncCommand LocateCommand { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public IEnumerable<string> Gender { get; set; } = new List<string> { "Male", "Female" };

        public string PassportN { get; set; }

        public Map Map { get; set; }

        public string Address { get; set; }

        public string ZipCode { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public Position Coordinates { get; set; }

        public ImageSource AccountImageSource { get; set; } = "avatar.jpg";

        public IAsyncCommand TakeCommand { get; set; }

        public IAsyncCommand PickCommand { get; set; }

        public IList<UserImagesViewModel> ImgItems { get; set; }

        public IAsyncCommand AddCommand { get; set; }

        public ISelectedItemDetailsViewModel ImgDetails { get; set; }

        public IViewModelValidator Validator { get; }
    }
}