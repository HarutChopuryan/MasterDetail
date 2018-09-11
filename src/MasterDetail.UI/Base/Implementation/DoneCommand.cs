using System.Threading;
using System.Threading.Tasks;
using MasterDetail.UI.Main.Implementation;

namespace MasterDetail.UI.Base.Implementation
{
    public class DoneCommand : AsyncCommand
    {
        private readonly CountryPickerViewModel _viewModel;

        public DoneCommand(CountryPickerViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        protected override async Task<bool> ExecuteCoreAsync(object parameter = null,
            CancellationToken token = default(CancellationToken))
        {
            return true;
        }
    }
}