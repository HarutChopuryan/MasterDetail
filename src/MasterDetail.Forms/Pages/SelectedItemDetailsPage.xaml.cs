using MasterDetail.Core.DI;
using MasterDetail.UI.Main;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterDetail.Forms.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectedItemDetailsPage : ContentPage
    {
        private readonly IUserViewModel _viewModel;

        public SelectedItemDetailsPage(IUserViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();
            BindingContext = _viewModel.ImgDetails;
        }
    }
}