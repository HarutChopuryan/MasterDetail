using System.Collections.Generic;
using MasterDetail.UI.Base;
using MasterDetail.UI.Main.Implementation;
using Xamarin.Forms;

namespace MasterDetail.UI.Main
{
    public interface IUserViewModel
    {
        string Name { get; set; }

        string Surname { get; set; }

        string Email { get; set; }

        ImageSource AccountImageSource { get; set; }

        IAsyncCommand TakeCommand { get; set; }

        IAsyncCommand PickCommand { get; set; }

        IList<UserImagesViewModel> ImgItems { get; set; }

        IAsyncCommand AddCommand { get; set; }

        ISelectedItemDetailsViewModel ImgDetails { get; set; }

        IAsyncCommand ImgDetailsCommand { get; set; }
    }
}