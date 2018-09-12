using System;
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

        protected override async Task<bool> ExecuteCoreAsync(object parameter = null,
            CancellationToken token = default(CancellationToken))
        {
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

            return true;
        }
    }
}