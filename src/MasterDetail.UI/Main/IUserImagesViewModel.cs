﻿using Xamarin.Forms;

namespace MasterDetail.UI.Main
{
    public interface IUserImagesViewModel
    {
        ImageSource ImageSource { get; set; }

        string ImageName { get; set; }
    }
}