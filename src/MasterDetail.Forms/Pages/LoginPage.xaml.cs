using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterDetail.Core.DI;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterDetail.Forms.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
		    NavigationPage.SetHasNavigationBar(this, false);
			InitializeComponent ();
		}

	    private async void OnSigninClicked(object sender, EventArgs e)
	    {
	        var userPage = ServiceLocator.Instance.Locate<MasterDetailMainPage>();
	        await Navigation.PushAsync(userPage);
	    }
	}
}