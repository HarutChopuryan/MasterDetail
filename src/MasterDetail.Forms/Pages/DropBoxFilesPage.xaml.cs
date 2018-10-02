using MasterDetail.Core.DI;
using MasterDetail.Core.Services;
using MasterDetail.UI.Main;
using MasterDetail.UI.Main.Implementation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterDetail.Forms.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DropBoxFilesPage : ContentPage
    {
        private readonly IUserViewModel _viewModel;

        public DropBoxFilesPage(IUserViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.DbName = DependencyService.Get<IPath>().GetDatabasePath(App.DBNAME);
            _viewModel.ImgDetails.DbName = _viewModel.DbName;
            InitializeComponent();
            BindingContext = _viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.LoadImagesFromCacheCommand.ExecuteAsync();
        }

        private async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectedItemDetailPage = ServiceLocator.Instance.Locate<SelectedItemDetailsPage>();
            await _viewModel.ImgDetails.ShowTappedImgCommand.ExecuteAsync(e);
            await Navigation.PushAsync(selectedItemDetailPage);
        }
    }
}