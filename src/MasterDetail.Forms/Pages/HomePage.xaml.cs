using System.IO;
using Dropbox.Api;
using Dropbox.Api.Files;
using MasterDetail.UI.Main;
using MasterDetail.UI.Main.Implementation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterDetail.Forms.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        private readonly IUserViewModel _viewModel;

        public HomePage(IUserViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();
            BindingContext = _viewModel;
        }

        //protected override async void OnAppearing()
        //{
        //    base.OnAppearing();
        //    var _accessKey = "Qg1P2iJ2DrAAAAAAAAAADLjGU5TlXqZgqTbejadackNzMBEkVrWO86BPK5qLNrX9";

        //    using (var client = new DropboxClient(_accessKey))
        //    {
        //        var list = await client.Files.ListFolderAsync(string.Empty);

        //        foreach (var item in list.Entries)
        //        {
        //            if (!item.IsFile || !item.Name.EndsWith(".jpg") && !item.Name.EndsWith(".png")) continue;

        //            Stream s = new MemoryStream();
        //            var resp = await client.Files.DownloadAsync("/nature.jpg");
        //            resp.GetContentAsStreamAsync().Result.CopyTo(s);
        //            Stream ds = await resp.GetContentAsStreamAsync();
        //            await ds.CopyToAsync(s);
        //            ds.Dispose();

        //            _viewModel.ImgItems.Add(new UserImagesViewModel
        //            {
        //                ImageSource = ImageSource.FromStream(()=>s),
        //                ImageName = item.Name
        //            });
        //        }
        //    }
        //}
    }
}