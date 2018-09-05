using System;
using System.Threading.Tasks;
using Dropbox.Api;
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

        protected override void OnAppearing()
        {
            base.OnAppearing();
            PhotoButtonsStackLayout.IsVisible = false;
            var _accessKey = "Qg1P2iJ2DrAAAAAAAAAADLjGU5TlXqZgqTbejadackNzMBEkVrWO86BPK5qLNrX9";
            Task.Run(async () =>
            {
                using (var dbx = new DropboxClient(_accessKey))
                {
                    var full = await dbx.Users.GetCurrentAccountAsync();
                    if (full != null)
                    {
                        _viewModel.Name = full.Name.DisplayName.Split(' ')[0];
                        _viewModel.Surname = full.Name.DisplayName.Split(' ')[1];
                        _viewModel.Email = full.Email;
                    }
                }
            });
        }

        private void OnMasterImgEditClicked(object sender, EventArgs e)
        {
            PhotoButtonsStackLayout.IsVisible = !PhotoButtonsStackLayout.IsVisible;
        }
    }
}