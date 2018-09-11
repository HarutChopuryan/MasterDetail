using System;
using Grace.DependencyInjection.Lifestyle;
using MasterDetail.Core.DI;
using MasterDetail.UI.Main;
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

        private void OnLocateClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MapPage(_viewModel));
        }

        private async void OnDropBoxButtonClicked(object sender, EventArgs e)
        {
            var dropBoxPage = ServiceLocator.Instance.Locate<DropBoxFilesPage>(LifestyleType.Singleton);
            await Navigation.PushAsync(dropBoxPage);
        }
    }
}