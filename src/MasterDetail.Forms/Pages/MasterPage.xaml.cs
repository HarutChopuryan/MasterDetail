using System;
using MasterDetail.Core.DI;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterDetail.Forms.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : ContentPage
    {
        public MasterPage()
        {
            InitializeComponent();
        }

        private void OnMasterImgEditClicked(object sender, EventArgs e)
        {
            var photoPage = ServiceLocator.Instance.Locate<PhotoPage>();
            Navigation.PushAsync(photoPage);
        }
    }
}