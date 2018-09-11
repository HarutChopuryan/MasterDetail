using System;
using MasterDetail.UI.Main;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace MasterDetail.Forms.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        private static int _firstTime;

        private readonly IUserViewModel _viewModel;

        public MapPage(IUserViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            _viewModel.Map = new Map(MapSpan.FromCenterAndRadius(new Position(37, -122), Distance.FromMiles(0.3)))
            {
                IsShowingUser = true,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            MainContent.Content = _viewModel.Map;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (_firstTime == 0)
            {
                _viewModel.Map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(40.1772, 44.50349), Distance.FromMiles(0.7)));
                _firstTime++;
            }
            else
            {
                _viewModel.Map.MoveToRegion(MapSpan.FromCenterAndRadius(_viewModel.Coordinates, Distance.FromKilometers(0.1)));
            }
        }

        private async void OnMapDoneClicked(object sender, EventArgs e)
        {
            await _viewModel.LocateCommand.ExecuteAsync();
            await Navigation.PopAsync();
        }
    }
}