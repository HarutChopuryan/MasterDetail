using System.Collections.Generic;
using MasterDetail.Core.Services;
using MasterDetail.UI.Base;
using MasterDetail.UI.Main.Implementation;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MasterDetail.UI.Main
{
    public interface IUserViewModel : IValidateableViewModel
    {
        string Name { get; set; }

        string Surname { get; set; }

        string Email { get; set; }

        string DbName { get; set; }

        string PassportN { get; set; }

        string Address { get; set; }

        string ZipCode { get; set; }

        string Country { get; set; }

        string City { get; set; }

        Position Coordinates { get; set; }

        Map Map { get; set; }

        ImageSource AccountImageSource { get; set; }

        IAsyncCommand TakeCommand { get; set; }

        IAsyncCommand PickCommand { get; set; }

        IAsyncCommand LocateCommand { get; set; }

        IAsyncCommand AddCommand { get; set; }

        IAsyncCommand SyncCommand { get; set; }

        IAsyncCommand RefreshCommand { get; set; }

        IAsyncCommand LoadDropboxImagesCommand { get; set; }

        IAsyncCommand LoadImagesFromCacheCommand { get; set; }

        IAsyncCommand UserInfoInitCommand { get; set; }

        IEnumerable<string> Gender { get; set; }

        IList<UserImagesViewModel> ImgItems { get; set; }

        ISelectedItemDetailsViewModel ImgDetails { get; set; }
    }
}