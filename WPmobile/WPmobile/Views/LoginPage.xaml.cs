using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPmobile.Service;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WPmobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        public static RestManager RestManager { get; private set; }

        public LoginPage ()
		{
			InitializeComponent ();
		}
        async void onNextPageButtonClicked(object sender, EventArgs e)
        {


            if (!string.IsNullOrEmpty(usernameEntry.Text) && !string.IsNullOrEmpty(usernameEntry.Text))
            {
                RestManager = new RestManager(new RestService(usernameEntry.Text, passwordEntry.Text));

                var employees = RestManager.GetAllEmployeesAsync().Result;

                await Navigation.PushAsync(new ProfilePage(employees));

            }




        }

        private void RememberMe_Toggled(object sender, ToggledEventArgs e)
        {

        }
    }
}