using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AplicatiePractica
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            /*var settings = MongoClientSettings.FromConnectionString("mongodb+srv://Cristina:<>@atlascluster.c9klwxy.mongodb.net/?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var database = client.GetDatabase("test");*/
           
            //MainPage = new MainPage();

            MainPage = new NavigationPage(new Login());
            //MainPage = new NavigationPage(new Register());
            //MainPage = new NavigationPage(new Home());
            //MainPage = new NavigationPage(new Chat());

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
