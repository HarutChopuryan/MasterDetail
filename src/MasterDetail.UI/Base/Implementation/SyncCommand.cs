using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dropbox.Api;
using MasterDetail.Core.EFCore;
using MasterDetail.Core.Services.Implementation;
using MasterDetail.UI.Main;
using MasterDetail.UI.Main.Implementation;
using Xamarin.Forms;
using Image = MasterDetail.Core.EFCore.Models.Image;

namespace MasterDetail.UI.Base.Implementation
{
    public class SyncCommand : AsyncCommand
    {
        private readonly IUserViewModel _viewModel;

        public SyncCommand(IUserViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        protected override async Task<bool> ExecuteCoreAsync(object parameter = null,
            CancellationToken token = default(CancellationToken))
        {
            var _accessKey = "Qg1P2iJ2DrAAAAAAAAAADLjGU5TlXqZgqTbejadackNzMBEkVrWO86BPK5qLNrX9";

            using (var client = new DropboxClient(_accessKey))
            {
                using (var work = new DbWork(new ImageContext(_viewModel.DbName)))
                {
                    var list = await client.Files.ListFolderAsync(string.Empty);
                    if (list.Entries.Count > work.Images.GetAll().Count())
                    {
                        for (var i = work.Images.GetAll().Count(); i < list.Entries.Count; i++)
                        {
                            var result = client.Files.GetTemporaryLinkAsync($"/{list.Entries[i].Name}");
                            var url = result.GetAwaiter().GetResult().Link;
                            var imgSourceUri = new UriImageSource
                            {
                                Uri = new Uri(url)
                            };
                            work.Images.Add(new Image
                            {
                                ImageSource = StreamToByte(await imgSourceUri.GetStreamAsync(token)),
                                ImageName = list.Entries[i].Name
                            });
                            work.Complete();

                            _viewModel.ImgItems.Add(new UserImagesViewModel
                            {
                                ImageSource = imgSourceUri,
                                ImageName = list.Entries[i].Name
                            });
                        }
                        await _viewModel.RefreshCommand.ExecuteAsync(token: token);
                    }
                    else if (list.Entries.Count < work.Images.GetAll().Count())
                    {
                        if (list.Entries.Count == 0)
                        {
                            work.Images.Clear();
                        }
                        else
                        {
                            var existingItems = new List<string>();
                            foreach (var dropBoxImage in list.Entries)
                                if (!dropBoxImage.IsDeleted)
                                    existingItems.Add(dropBoxImage.Name);

                            foreach (var dbImage in work.Images.GetAll())
                                if (!existingItems.Contains(dbImage.ImageName))
                                {
                                    var img = work.Images.GetAll().First(item => item.ImageName == dbImage.ImageName);
                                    work.Images.Remove(img);
                                }
                        }
                        work.Complete();
                        await _viewModel.RefreshCommand.ExecuteAsync(token: token);
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