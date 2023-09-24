using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Realms;
using MongoDB.Bson;
using AplicatiePractica.DataModels;
using AplicatiePractica.DB;

namespace AplicatiePractica
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        private string imgUrl = "https://ps.w.org/user-avatar-reloaded/assets/icon-256x256.png?rev=2540745";
        Realm realm;
        public Register()
        {
            InitializeComponent();
            realm = RealmProvider.RealmInstance;
        }

        private void Login_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync (new Login());
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            bool correctFields = true;
            if (txtName.Text == "")
            {
                correctFields = false;
                DisplayAlert("", "Enter your Name!", "OK");
            }
            else if (txtEmail.Text == "")
            {
                correctFields = false;
                DisplayAlert("", "Enter your email!", "OK");
            }
            else if (txtPassword.Text == "")
            {
                correctFields = false;
                DisplayAlert("", "Enter your password!", "OK");
            }
            else if (txtEmail.Text.IndexOf("@") == -1)
            {
                correctFields = false;
                DisplayAlert("Error!", "Not a valid email address!", "OK");
            }
            else if (txtEmail.Text.IndexOf(" ") >= 1)
            {
                correctFields = false;
                DisplayAlert("Error!", "Not a valid email address!", "OK");
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(txtName.Text, "^[a-zA-Z\\s]+$"))
            {
                correctFields = false;
                DisplayAlert("Error!", "Invalid name!", "OK");
            }
            else if(txtPassword.Text != txtConfirmPassword.Text)
            {
                correctFields = false;
                DisplayAlert("Error!", "Passwords not matching!", "OK");
            }

            if(correctFields)
            {
                realm.Write(() =>
                {
                    realm.Add(new Contact()
                    {
                        Email = txtEmail.Text,
                        ImageUrl = imgUrl,
                        Name = txtName.Text,
                        Password = txtPassword.Text
                    });
                });
                DisplayAlert("Information", $"User {txtName.Text} succesfully created!", "OK");
            }
       
        }
    }
}