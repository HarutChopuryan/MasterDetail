using Android.App;
using Android.Content.PM;
using Android.OS;
using Grace.DependencyInjection;
using MasterDetail.Core;
using MasterDetail.Core.DI;
using MasterDetail.Forms;
using MasterDetail.Forms.Pages;
using MasterDetail.UI;
using MasterDetail.UI.Main;
using MasterDetail.UI.Main.Implementation;
using Plugin.CurrentActivity;
using Plugin.Permissions;
using Xamarin.Forms.Platform.Android;

namespace MasterDetail.Droid
{
    [Activity(Label = "MasterDetail", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {
        private DependencyInjectionContainer _container;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            
            _container = new DependencyInjectionContainer();
            _container.RegisterCoreDependencies()
                .RegisterUIDependencies()
                .RegisterFormsDependencies()
                .RegisterDroidDependencies();
            ServiceLocator.Create(_container);

            Xamarin.FormsMaps.Init(this, savedInstanceState);
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(enableFastRenderer: true);
            CrossCurrentActivity.Current.Init(this, savedInstanceState);
            Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App(_container));
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions,
            Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}