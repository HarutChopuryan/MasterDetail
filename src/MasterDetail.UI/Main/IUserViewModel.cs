using System.Collections.Generic;
using MasterDetail.UI.Base;
using MasterDetail.UI.Main.Implementation;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MasterDetail.UI.Main
{
    public interface IUserViewModel : IValidateableViewModel
    {
        IAsyncCommand LocateCommand { get; set; }

        string Name { get; set; }

        string Surname { get; set; }

        string Email { get; set; }

        IEnumerable<string> Gender { get; set; }

        string PassportN { get; set; }

        Map Map { get; set; }

        string Address { get; set; }

        string ZipCode { get; set; }

        string Country { get; set; }

        string City { get; set; }

        Position Coordinates { get; set; }

        ImageSource AccountImageSource { get; set; }

        IAsyncCommand TakeCommand { get; set; }

        IAsyncCommand PickCommand { get; set; }

        IList<UserImagesViewModel> ImgItems { get; set; }

        IAsyncCommand AddCommand { get; set; }

        ISelectedItemDetailsViewModel ImgDetails { get; set; }
    }
}