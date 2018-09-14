using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Dropbox.Api;
using MasterDetail.UI.Main;
using MasterDetail.UI.Main.Implementation;
using Xamarin.Forms;

namespace MasterDetail.UI.Base.Implementation
{
    public class LoadDropboxImagesCommand : AsyncCommand
    {
        private readonly IUserViewModel _viewModel;

        public LoadDropboxImagesCommand(IUserViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        protected override async Task<bool> ExecuteCoreAsync(object parameter = null, CancellationToken token = default(CancellationToken))
        {
            if (_viewModel.ImgItems != null && _viewModel.ImgItems.Count == 0)
            {
                var _accessKey = "Qg1P2iJ2DrAAAAAAAAAADLjGU5TlXqZgqTbejadackNzMBEkVrWO86BPK5qLNrX9";

                using (var client = new DropboxClient(_accessKey))
                {
                    var list = await client.Files.ListFolderAsync(string.Empty);

                    Parallel.ForEach(list.Entries, item =>
                    {
                        if (!item.IsFile || !item.Name.EndsWith(".jpg") && !item.Name.EndsWith(".png"))
                            return;

                        var result = client.Files.GetTemporaryLinkAsync($"/{item.Name}");
                        var url = result.GetAwaiter().GetResult().Link;
                        var imgSourceUri = new UriImageSource
                        {
                            Uri = new Uri(url)
                        };

                        _viewModel.ImgItems.Add(new UserImagesViewModel
                        {
                            ImageSource = imgSourceUri,
                            ImageName = item.Name
                        });
                    });
                }
            }

            return true;
        }
    }
}