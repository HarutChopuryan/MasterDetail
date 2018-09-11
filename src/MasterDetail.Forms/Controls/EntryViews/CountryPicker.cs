using MasterDetail.Core.DI;
using MasterDetail.Forms.Pages;
using Xamarin.Forms;

namespace MasterDetail.Forms.Controls.EntryViews
{
    public class CountryPicker : EntryView
    {
        public CountryPicker()
        {
            TextEntry.Focused += TextEntryOnFocused;
        }

        private async void TextEntryOnFocused(object sender, FocusEventArgs e)
        {
            var countryPickerPage = ServiceLocator.Instance.Locate<CountryPickerPage>();
            countryPickerPage.SelectedCountry = Text;
            countryPickerPage.CountrySelected += CountrySelected;
            await Navigation.PushAsync(countryPickerPage, true);
        }

        private void CountrySelected(object sender, string country)
        {
            Text = country;
        }
    }
}