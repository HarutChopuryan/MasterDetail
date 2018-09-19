using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MasterDetail.Core.EFCore;
using MasterDetail.UI.Main;
using MasterDetail.UI.Main.Implementation;
using Xamarin.Forms;

namespace MasterDetail.UI.Base.Implementation
{
    public class RefreshCommand : AsyncCommand
    {
        private readonly IUserViewModel _viewModel;

        public RefreshCommand(IUserViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        protected override Task<bool> ExecuteCoreAsync(object parameter = null,
            CancellationToken token = default(CancellationToken))
        {
            using (var db = new ApplicationContext(_viewModel.DbName))
            {
                _viewModel.ImgItems.Clear();
                _viewModel.ImgItems = (from user in db.UserDropbox
                    select new UserImagesViewModel
                    {
                        ImageSource = ImageSource.FromStream(() => new MemoryStream(user.ImageSource)),
                        ImageName = user.ImageName
                    }).ToList();
            }
            return Task.FromResult(true);
        }
    }
}