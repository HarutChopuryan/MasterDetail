using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dropbox.Api;
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
	        //string _accessKey = "Qg1P2iJ2DrAAAAAAAAAADLjGU5TlXqZgqTbejadackNzMBEkVrWO86BPK5qLNrX9";
         //   var task = Task.Run(async () =>
	        //{
	        //    using (var dbx = new DropboxClient(_accessKey))
	        //    {
	        //        var full = await dbx.Users.GetCurrentAccountAsync();
	        //        if (full != null)
	        //        {
	        //            Debug.WriteLine("{0} - {1}", full.Name.DisplayName, full.Email);
	        //            var userPage = ServiceLocator.Instance.Locate<MasterDetailMainPage>();
	        //            await Navigation.PushAsync(userPage);
	        //        }
	        //    }
         //   });

	        var userPage = ServiceLocator.Instance.Locate<MasterDetailMainPage>();
	        await Navigation.PushAsync(userPage);
        }
	}
}