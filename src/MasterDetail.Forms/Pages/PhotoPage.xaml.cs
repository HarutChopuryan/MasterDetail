using System;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MasterDetail.UI.Main;

namespace MasterDetail.Forms.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PhotoPage : ContentPage
    {
        private readonly IUserPageViewModel _viewModel;

        public PhotoPage(IUserPageViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();
            BindingContext = _viewModel;
        }

        private async void OnTakeButtonClicked(object sender, EventArgs e)
        {
            await _viewModel.TakeCommand.ExecuteAsync();
        }

        private async void OnPickButtonClicked(object sender, EventArgs e)
        {
            await _viewModel.PickCommand.ExecuteAsync();
        }

        private async void OnPhotoDoneClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}