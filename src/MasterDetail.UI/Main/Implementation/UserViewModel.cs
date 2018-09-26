using System.Collections.Generic;
using System.Collections.ObjectModel;
using MasterDetail.Core.Services;
using MasterDetail.UI.Base;
using MasterDetail.UI.Base.Implementation;
using MasterDetail.UI.Validators;
using PropertyChanged;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Image=MasterDetail.Core.EFCore.Models.Image;

namespace MasterDetail.UI.Main.Implementation
{
    [AddINotifyPropertyChangedInterface]
    public class UserViewModel : BaseBindableObject, IUserViewModel
    {
        public UserViewModel(/*IRepository<Image> repository*/)
        {
            LoadImagesFromCacheCommand = new LoadImagesFromCacheCommand(this);
            LoadDropboxImagesCommand = new LoadDropboxImagesCommand(this);
            ImgItems = new ObservableCollection<UserImagesViewModel>();
            ImgDetails = new SelectedItemDetailsViewModel();
            TakeCommand = new TakeCommand(this);
            PickCommand = new PickCommand(this);
            AddCommand = new AddCommand(this);
            RefreshCommand = new RefreshCommand(this);
            Validator = new MainValidator(this);
            LocateCommand = new LocateCommand(this);
            SyncCommand = new SyncCommand(this);
        }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string DbName { get; set; }

        public string PassportN { get; set; }

        public string Address { get; set; }

        public string ZipCode { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public Position Coordinates { get; set; }

        public ImageSource AccountImageSource { get; set; } = "avatar.jpg";

        public Map Map { get; set; }

        public IAsyncCommand TakeCommand { get; set; }

        public IAsyncCommand LocateCommand { get; set; }

        public IAsyncCommand PickCommand { get; set; }

        public IAsyncCommand AddCommand { get; set; }

        public IAsyncCommand SyncCommand { get; set; }

        public IAsyncCommand RefreshCommand { get; set; }

        public IAsyncCommand LoadDropboxImagesCommand { get; set; }

        public IAsyncCommand LoadImagesFromCacheCommand { get; set; }

        public IList<UserImagesViewModel> ImgItems { get; set; }

        public IEnumerable<string> Gender { get; set; } = new List<string> {"Male", "Female"};

        public ISelectedItemDetailsViewModel ImgDetails { get; set; }

        public IViewModelValidator Validator { get; }
    }
}