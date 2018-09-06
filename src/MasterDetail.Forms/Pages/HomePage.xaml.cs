using MasterDetail.UI.Main;
using MasterDetail.UI.Main.Implementation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterDetail.Forms.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        private readonly IUserViewModel _viewModel;

        public HomePage(IUserViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();
            BindingContext = _viewModel;
        }
    }
}