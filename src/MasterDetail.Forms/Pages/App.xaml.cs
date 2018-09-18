using Grace.DependencyInjection;
using Grace.DependencyInjection.Lifestyle;
using MasterDetail.Core.DI;
using MasterDetail.UI.Main;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MasterDetail.Forms.Pages
{
    public partial class App : Application
    {
        private readonly DependencyInjectionContainer _container;

        public const string DBNAME = "userdropbox.db";

        public App(DependencyInjectionContainer container)
        {
            _container = container;
            InitializeComponent();
            MainPage = new MasterDetailMainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
