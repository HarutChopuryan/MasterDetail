using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MasterDetail.UI.Main.Implementation;

namespace MasterDetail.UI.Base.Implementation
{
    public class SearchCommand : AsyncCommand
    {
        private readonly CountryPickerViewModel _viewModel;

        private CancellationTokenSource _searchCancellationToken;

        public SearchCommand(CountryPickerViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        protected override async Task<bool> ExecuteCoreAsync(object parameter = null,
            CancellationToken token = default(CancellationToken))
        {
            CancellationTokenSource searchCancellationToken = null;
            try
            {
                _searchCancellationToken?.Cancel();
                searchCancellationToken = _searchCancellationToken = new CancellationTokenSource();

                if (_viewModel.BaseItems?.Any() == true && !string.IsNullOrWhiteSpace(_viewModel.SearchText))
                {
                    await Task.Delay(2000, searchCancellationToken.Token);
                    var result = _viewModel.BaseItems
                        .Where(item => item.ToLower().Contains(_viewModel.SearchText.ToLower()))
                        .ToList();
                    ++_viewModel.Count;
                    _viewModel.Countries = result;
                    if (!_viewModel.Countries.Any())
                        _viewModel.SearchNotFound = "Country not found";
                }
                else
                {
                    _viewModel.Countries = _viewModel.BaseItems;
                }
            }
            catch (OperationCanceledException ex)
            {
                if (searchCancellationToken?.IsCancellationRequested != true) throw ex;
            }

            return true;
        }
    }
}