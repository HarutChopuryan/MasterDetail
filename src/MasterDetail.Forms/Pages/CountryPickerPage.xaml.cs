using System;
using MasterDetail.UI.Main;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterDetail.Forms.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CountryPickerPage
    {
        private readonly ICountryPickerViewModel _viewModel;

        public EventHandler<string> CountrySelected;

        public CountryPickerPage(ICountryPickerViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();
            BindingContext = _viewModel;
            NavigationPage.SetHasBackButton(this, false);
        }

        public string SelectedCountry
        {
            get => _viewModel.SelectedCountry;
            set => _viewModel.SelectedCountry = value;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.LoadCountriesCommand.Execute(null);
        }

        private async void OnDoneClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
            if (_viewModel.SelectedCountry != null)
                CountrySelected.Invoke(this, listView.SelectedItem.ToString());
        }

        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            _viewModel.SearchText = searchBar.Text;
            _viewModel.SearchCommand.Execute(null);
        }
    }
}