using System;
using System.IO;
using System.Linq;
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
                using (var db = new ApplicationContext(_viewModel.DbName))
                {
                    var list = await client.Files.ListFolderAsync(string.Empty);
                    if (list.Entries.Count > db.UserDropbox.ToList().Count)
                    {
                        for (var i = db.UserDropbox.ToList().Count; i < list.Entries.Count; i++)
                        {
                            var result = client.Files.GetTemporaryLinkAsync($"/{list.Entries[i].Name}");
                            var url = result.GetAwaiter().GetResult().Link;
                            var imgSourceUri = new UriImageSource
                            {
                                Uri = new Uri(url)
                            };
                            db.UserDropbox.Add(new Image
                            {
                                ImageSource = StreamToByte(await imgSourceUri.GetStreamAsync(token)),
                                ImageName = list.Entries[i].Name
                            });
                            db.SaveChanges();

                            _viewModel.ImgItems.Add(new UserImagesViewModel
                            {
                                ImageSource = imgSourceUri,
                                ImageName = list.Entries[i].Name
                            });
                        }
                    }
                    else if (list.Entries.Count < db.UserDropbox.ToList().Count)
                    {
                        for (int i = 0; i < db.UserDropbox.ToList().Count; i++)
                        {
                            try
                            {
                                if(list.Entries.Count==0)
                                    db.UserDropbox.Local.Clear();
                                else if(list.Entries[i].Name != db.UserDropbox.ToList()[i].ImageName)
                                    db.UserDropbox.Remove(db.UserDropbox.Local.ElementAt(i));
                            }
                            catch (Exception e)
                            {
                                await _viewModel.RefreshCommand.ExecuteAsync(token: token);
                            }
                        }
                        db.SaveChanges();
                        await _viewModel.RefreshCommand.ExecuteAsync(token: token);
                    }
                }
            }

            await _viewModel.RefreshCommand.ExecuteAsync(token: token);
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