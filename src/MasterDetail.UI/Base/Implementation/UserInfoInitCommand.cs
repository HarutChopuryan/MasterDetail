using System.Threading;
using System.Threading.Tasks;
using Dropbox.Api;
using MasterDetail.UI.Main;

namespace MasterDetail.UI.Base.Implementation
{
    public class UserInfoInitCommand : AsyncCommand
    {
        private readonly IUserViewModel _viewModel;

        public UserInfoInitCommand(IUserViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        protected override Task<bool> ExecuteCoreAsync(object parameter = null,
            CancellationToken token = default(CancellationToken))
        {
            var _accessKey = "Qg1P2iJ2DrAAAAAAAAAADLjGU5TlXqZgqTbejadackNzMBEkVrWO86BPK5qLNrX9";
            Task.Run(async () =>
            {
                using (var dbx = new DropboxClient(_accessKey))
                {
                    var full = await dbx.Users.GetCurrentAccountAsync();
                    if (full != null)
                    {
                        _viewModel.Name = full.Name.DisplayName.Split(' ')[0];
                        _viewModel.Surname = full.Name.DisplayName.Split(' ')[1];
                        _viewModel.Email = full.Email;
                    }
                }
            });
            return Task.FromResult(true);
        }
    }
}