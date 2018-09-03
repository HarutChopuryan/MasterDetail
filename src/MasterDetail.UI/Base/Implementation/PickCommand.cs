using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MasterDetail.UI.Main;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;

namespace MasterDetail.UI.Base.Implementation
{
    public class PickCommand : AsyncCommand
    {
        private readonly IUserPageViewModel _viewModel;

        public PickCommand(IUserPageViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        protected override async Task<bool> ExecuteCoreAsync(object parameter = null,
            CancellationToken token = default(CancellationToken))
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                return false;
            }

            var file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
            {
                PhotoSize = PhotoSize.Medium
            });


            if (file == null)
                return false;

            _viewModel.ImageSource = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });

            return true;
        }
    }
}