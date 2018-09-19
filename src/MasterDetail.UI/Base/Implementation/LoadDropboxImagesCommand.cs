using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Dropbox.Api;
using MasterDetail.Core.EFCore;
using MasterDetail.UI.Main;
using MasterDetail.UI.Main.Implementation;
using Xamarin.Forms;
using Image = MasterDetail.Core.EFCore.Models.Image;

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
                        if (!item.IsFile || !item.Name.EndsWith(".jpg") && !item.Name.EndsWith(".png"))
                            continue;
                        var result = client.Files.GetTemporaryLinkAsync($"/{item.Name}");
                        var url = result.GetAwaiter().GetResult().Link;
                        var imgSourceUri = new UriImageSource
                        {
                            Uri = new Uri(url)
                        };
                        using (var db = new ApplicationContext(_viewModel.DbName))
                        {
                            db.UserDropbox.Add(new Image
                            {
                                ImageSource = StreamToByte(await imgSourceUri.GetStreamAsync(token)),
                                ImageName = item.Name
                            });
                            db.SaveChanges();
                        }

                        _viewModel.ImgItems.Add(new UserImagesViewModel
                        {
                            ImageSource = imgSourceUri,
                            ImageName = item.Name
                        });
                    }
                }
            }

            return true;
        }

        public static byte[] StreamToByte(Stream input)
        {
            var buffer = new byte[16 * 1024];
            using (var ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0) ms.Write(buffer, 0, read);
                return ms.ToArray();
            }
        }
    }
}