﻿using System.Threading;
using System.Threading.Tasks;
using Dropbox.Api;
using Dropbox.Api.Files;
using MasterDetail.UI.Main;
using MasterDetail.UI.Main.Implementation;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;

namespace MasterDetail.UI.Base.Implementation
{
    public class PickCommand : AsyncCommand
    {
        private readonly IUserViewModel _viewModel;

        public PickCommand(IUserViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        protected override async Task<bool> ExecuteCoreAsync(object parameter = null,
            CancellationToken token = default(CancellationToken))
        {
            if (!CrossMedia.Current.IsPickPhotoSupported) return false;

            var file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
            {
                PhotoSize = PhotoSize.Medium
            });


            if (file == null)
                return false;

            _viewModel.AccountImageSource = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                return stream;
            });

            string imageName = file.Path.Substring(file.Path.LastIndexOf('/') + 1);

            _viewModel.ImgItems.Add(new UserImagesViewModel()
            {
                ImageSource = _viewModel.AccountImageSource,
                ImageName = imageName
            });

            var _accessKey = "Qg1P2iJ2DrAAAAAAAAAADLjGU5TlXqZgqTbejadackNzMBEkVrWO86BPK5qLNrX9";

            using (var client = new DropboxClient(_accessKey))
            {
                var ci = new CommitInfo($"/{imageName}");
                var resp = await client.Files.UploadAsync(ci, file.GetStream());
            }
            file.Dispose();

            return true;
        }
    }
}