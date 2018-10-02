using System;
using MasterDetail.Core.DI;
using MasterDetail.UI.Main;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterDetail.Forms.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPage : ContentPage
    {
        private readonly IUserViewModel _viewModel;

        public UserPage()
        {
            _viewModel = ServiceLocator.Instance.Locate<IUserViewModel>();
            InitializeComponent();
            BindingContext = _viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            PhotoButtonsStackLayout.IsVisible = false;
            _viewModel.UserInfoInitCommand.ExecuteAsync();
        }

        private void OnMasterImgEditClicked(object sender, EventArgs e)
        {
            PhotoButtonsStackLayout.IsVisible = !PhotoButtonsStackLayout.IsVisible;
        }
    }
}