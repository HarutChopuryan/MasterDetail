using System;
using System.Threading;
using System.Threading.Tasks;
using Dropbox.Api;
using Dropbox.Api.Files;
using MasterDetail.UI.Main;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;

namespace MasterDetail.UI.Base.Implementation
{
    public class TakeCommand : AsyncCommand
    {
        private readonly IUserViewModel _viewModel;

        public TakeCommand(IUserViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        protected override async Task<bool> ExecuteCoreAsync(object parameter = null,
            CancellationToken token = default(CancellationToken))
        {
            if (CrossMedia.Current.IsCameraAvailable && CrossMedia.Current.IsTakePhotoSupported)
            {
                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported) return false;

                var imageProperties = new StoreCameraMediaOptions
                {
                    Directory = "Test",
                    SaveToAlbum = true,
                    Name = $"{DateTime.Now:dd.MM.yyyy_hh.mm.ss}.jpg",
                    CompressionQuality = 75,
                    CustomPhotoSize = 50,
                    PhotoSize = PhotoSize.MaxWidthHeight,
                    MaxWidthHeight = 2000,
                    DefaultCamera = CameraDevice.Front
                };

                var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    Directory = "Test",
                    SaveToAlbum = true,
                    Name = $"{DateTime.Now:dd.MM.yyyy_hh.mm.ss}.jpg",
                    CompressionQuality = 75,
                    CustomPhotoSize = 50,
                    PhotoSize = PhotoSize.MaxWidthHeight,
                    MaxWidthHeight = 2000,
                    DefaultCamera = CameraDevice.Front
                });

                if (file == null)
                    return false;

                _viewModel.ImageSource = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                });

                var _accessKey = "Qg1P2iJ2DrAAAAAAAAAADLjGU5TlXqZgqTbejadackNzMBEkVrWO86BPK5qLNrX9";

                using (var client = new DropboxClient(_accessKey))
                {
                    var ci = new CommitInfo($"/{file.Path.Substring(file.Path.LastIndexOf('/') + 1)}");
                    var resp = await client.Files.UploadAsync(ci, file.GetStream());
                }
            }

            return true;
        }
    }
}