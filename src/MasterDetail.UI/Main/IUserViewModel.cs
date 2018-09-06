using System.Collections.Generic;
using MasterDetail.UI.Base;
using Xamarin.Forms;

namespace MasterDetail.UI.Main
{
    public interface IUserViewModel
    {
        string Name { get; set; }

        string Surname { get; set; }

        string Email { get; set; }

        ImageSource ImageSource { get; set; }

        IAsyncCommand TakeCommand { get; set; }

        IAsyncCommand PickCommand { get; set; }

        IList<string> ImgItems { get; set; }

        IAsyncCommand AddCommand { get; set; }
    }
}