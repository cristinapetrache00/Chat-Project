using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AplicatiePractica.DataModels;
using Realms;

using MongoDB.Bson;
using AplicatiePractica.DB;

namespace AplicatiePractica
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();

            var realm = RealmProvider.RealmInstance;
            var allContacts = realm.All<Contact>().ToList();
            myListView.ItemsSource = allContacts;

        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Chat());
        }
        private void TapGestureRecognizer_Tapped0(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Login());
            DisplayAlert("Information", "You have successfully logged out!", "OK");
        }
    }

    
}