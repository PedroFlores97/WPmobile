using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPmobile.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WPmobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProfilePage : ContentPage
	{
        public List<Employee> ListEmployees { get; set; }

        public ProfilePage (List<Employee> emplList)
		{
			InitializeComponent ();

            ListEmployees = emplList;

            var asc = ListEmployees.OrderBy(item => item.LastName).ToList();
            var desc = ListEmployees.OrderByDescending(item => item.DisplayName).ToList();


            ViewList.ItemsSource = asc;
        }

        private void OnSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchTerm = OnSearch.Text;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                var searchResult = ListEmployees.Where(x => x.DisplayName.ToLower().Contains(searchTerm.ToLower())).ToList();
                ViewList.ItemsSource = searchResult;
            }
            else
            {
                ViewList.ItemsSource = ListEmployees;
            }
        }

        async void MainListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //if (e.SelectedItem == null)
            // return;
            Employee emp = (Employee)((ListView)sender).SelectedItem;
            await DisplayAlert("Item Tapped", emp.EmplID, "OK");


            // Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}