using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MasterDetail.Core.EFCore;
using MasterDetail.Core.Services.Implementation;
using MasterDetail.UI.Main;
using MasterDetail.UI.Main.Implementation;
using Xamarin.Forms;
using Image=MasterDetail.Core.EFCore.Models.Image;

namespace MasterDetail.UI.Base.Implementation
{
    public class ShowTappedImgCommand : AsyncCommand
    {
        private readonly ISelectedItemDetailsViewModel _viewModel;

        public ShowTappedImgCommand(ISelectedItemDetailsViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        protected override Task<bool> ExecuteCoreAsync(object parameter = null,
            CancellationToken token = default(CancellationToken))
        {
            var param = (ItemTappedEventArgs) parameter;
            var TappedImgInfo = param.Item as UserImagesViewModel;
            using (var work = new DbWork(new ImageContext(_viewModel.DbName)))
            {
                int id = work.Images.GetAll().Where(c => c.ImageName == TappedImgInfo.ImageName).Select(a => a.Id)
                    .First();
                Image img = work.Images.GetById(id);
                _viewModel.Name = img.ImageName;
                _viewModel.ImageSource = ImageSource.FromStream(() => new MemoryStream(img.ImageSource));
            }
            return Task.FromResult(true);
        }
    }
}