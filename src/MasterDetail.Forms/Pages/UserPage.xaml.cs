using System;
using System.ComponentModel;
using MasterDetail.Core.DI;
using MasterDetail.UI.Main;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterDetail.Forms.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPage : ContentPage
    {
        private readonly IUserPageViewModel _viewModel;

        public UserPage(IUserPageViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();
            BindingContext = _viewModel;
        }

        private void OnMasterImgEditClicked(object sender, EventArgs e)
        {
            PhotoButtonsStackLayout.IsVisible = !PhotoButtonsStackLayout.IsVisible;
        }
    }
}