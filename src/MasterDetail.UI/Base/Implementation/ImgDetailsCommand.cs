using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MasterDetail.Core.Extensions;
using MasterDetail.UI.Main;
using MasterDetail.UI.Main.Implementation;
using ListView = Xamarin.Forms.ListView;

namespace MasterDetail.UI.Base.Implementation
{
    public class ImgDetailsCommand : AsyncCommand
    {
        private readonly IUserViewModel _viewModel;

        public ImgDetailsCommand(IUserViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        protected override Task<bool> ExecuteCoreAsync(object parameter = null,
            CancellationToken token = default(CancellationToken))
        {
            var listView = (ListView) parameter;
            if (listView != null)
            {
                var index =
                    ((ObservableCollection<UserImagesViewModel>) listView.ItemsSource).IndexOf(listView.SelectedItem);
                var a = listView.ItemsSource.ToArray().Where((c, indexx) => index == indexx);
            }

            //_viewModel.ImgDetails.Camera = listView.ItemsSource.GetElementAt(index).ToString();
            //_viewModel.ImgDetails.Date = "dat";
            //_viewModel.ImgDetails.Dimension = "Dim";
            //_viewModel.ImgDetails.Path = "Pat";
            //_viewModel.ImgDetails.Size = "Siz";
            //_viewModel.ImgDetails.Type = "Typ";
            return Task.FromResult(true);
        }
    }
}