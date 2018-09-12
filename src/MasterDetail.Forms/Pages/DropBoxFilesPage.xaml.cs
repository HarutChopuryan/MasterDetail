using System;
using Dropbox.Api;
using MasterDetail.Core.DI;
using MasterDetail.UI.Main;
using MasterDetail.UI.Main.Implementation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterDetail.Forms.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DropBoxFilesPage : ContentPage
    {
        private readonly IUserViewModel _viewModel;

        public DropBoxFilesPage(IUserViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();
            BindingContext = _viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (_viewModel.ImgItems != null && _viewModel.ImgItems.Count == 0)
            {
                var _accessKey = "Qg1P2iJ2DrAAAAAAAAAADLjGU5TlXqZgqTbejadackNzMBEkVrWO86BPK5qLNrX9";

                using (var client = new DropboxClient(_accessKey))
                {
                    var list = await client.Files.ListFolderAsync(string.Empty);

                    foreach (var item in list.Entries)
                    {
                        if (!item.IsFile || !item.Name.EndsWith(".jpg") && !item.Name.EndsWith(".png")) continue;

                        var result = await client.Files.GetTemporaryLinkAsync($"/{item.Name}");
                        var url = result.Link;

                        _viewModel.ImgItems.Add(new UserImagesViewModel
                        {
                            ImageSource = ImageSource.FromUri(new Uri(url)),
                            ImageName = item.Name
                        });
                    }
                }
            }
        }

        private async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var userImagesViewModel = e.Item as UserImagesViewModel;
            var selectedItemDetailPage = ServiceLocator.Instance.Locate<SelectedItemDetailsPage>();
            selectedItemDetailPage.ViewModel = _viewModel.ImgDetails;
            if (userImagesViewModel != null)
                selectedItemDetailPage.ViewModel.Name = userImagesViewModel.ImageName;
            await Navigation.PushAsync(selectedItemDetailPage);
        }
    }
}