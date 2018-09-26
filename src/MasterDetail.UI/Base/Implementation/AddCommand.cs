using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Dropbox.Api;
using Dropbox.Api.Files;
using MasterDetail.Core.EFCore;
using MasterDetail.UI.Main;
using MasterDetail.UI.Main.Implementation;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;
using Image = MasterDetail.Core.EFCore.Models.Image;

namespace MasterDetail.UI.Base.Implementation
{
    public class AddCommand : AsyncCommand
    {
        private readonly IUserViewModel _viewModel;

        public AddCommand(IUserViewModel viewModel)
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

            string imageName = file.Path.Substring(file.Path.LastIndexOf('/') + 1);

            //ImageSource source = ImageSource.FromStream(() => file.GetStream());

            //using (var db = new ImageContext(_viewModel.DbName))
            //{
            //    db.UserDropbox.Add(new Image
            //    {
            //        ImageSource = StreamToByte(file.GetStream()),
            //        ImageName = imageName
            //    });
            //    file.Dispose();
            //    db.SaveChanges();
            //}

            //_viewModel.ImgItems.Add(new UserImagesViewModel()
            //{
            //    ImageSource = source,
            //    ImageName = imageName
            //});

            var _accessKey = "Qg1P2iJ2DrAAAAAAAAAADLjGU5TlXqZgqTbejadackNzMBEkVrWO86BPK5qLNrX9";

            using (var client = new DropboxClient(_accessKey))
            {
                var ci = new CommitInfo($"/{imageName}");
                var resp = await client.Files.UploadAsync(ci, file.GetStream());
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