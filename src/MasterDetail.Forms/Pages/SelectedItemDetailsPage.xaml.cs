using MasterDetail.UI.Main;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterDetail.Forms.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectedItemDetailsPage : ContentPage
    {
        public SelectedItemDetailsPage()
        {
            InitializeComponent();
        }

        public ISelectedItemDetailsViewModel ViewModel
        {
            get => (ISelectedItemDetailsViewModel) BindingContext;
            set => BindingContext = value;
        }
    }
}