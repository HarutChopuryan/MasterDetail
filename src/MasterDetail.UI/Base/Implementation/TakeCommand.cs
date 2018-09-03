using System;
using System.Threading;
using System.Threading.Tasks;
using MasterDetail.UI.Main;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;

namespace MasterDetail.UI.Base.Implementation
{
    public class TakeCommand : AsyncCommand
    {
        private readonly IUserPageViewModel _viewModel;

        public TakeCommand(IUserPageViewModel viewModel)
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
            }

            return true;
        }
    }
}