using System;
using System.Collections.Generic;
using System.Text;
using MasterDetail.UI.Base;
using Xamarin.Forms;

namespace MasterDetail.UI.Main
{
    public interface IUserPageViewModel
    {
        string Name { get; set; }

        string Surname { get; set; }

        string Email { get; set; }

        ImageSource ImageSource { get; set; }

        IAsyncCommand TakeCommand { get; set; }

        IAsyncCommand PickCommand { get; set; }
    }
}