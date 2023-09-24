using AplicatiePractica.DataModels;
using AplicatiePractica.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AplicatiePractica
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                DisplayAlert("", "Enter your username!", "OK");
            }
            else if (txtPassword.Text == "")
            {
                DisplayAlert("", "Enter your password!", "OK");
            }
            else if (txtUsername.Text.IndexOf("@") == -1)
            {
                DisplayAlert("Error!", "Not a valid email address!", "OK");
            }
            else if (txtUsername.Text.IndexOf(" ") >= 1) 
            {
                DisplayAlert("Error!", "Not a valid email address!", "OK");
            } 
            else if (CHeckUserCredentials(txtUsername.Text, txtPassword.Text))
            {
                Navigation.PushAsync(new Home());
            }
            else
            {
                DisplayAlert("Warning!", "Username or Password is incorrect!", "OK");
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Register());
        }
        private bool CHeckUserCredentials(string email, string password)
        {
            var realm = RealmProvider.RealmInstance;
            var allContacts = realm.All<Contact>();
            foreach(var contact in allContacts)
            {
                if (contact.Email.Equals(email, StringComparison.InvariantCultureIgnoreCase) && contact.Password.Equals(password))
                    return true;
            }
            return false;

        }
    }
}