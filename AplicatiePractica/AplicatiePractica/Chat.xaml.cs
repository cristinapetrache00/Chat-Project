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
    public partial class Chat : ContentPage
    {
        public Chat()
        {
            var realm = RealmProvider.RealmInstance;
            var messageList = realm.All<SendMessage>().ToList();
            lvChat.ItemsSource = messageList;
        }

        private void InsertSendMessageIntoDB(string message, string senderName)
        {
            var realm = RealmProvider.RealmInstance;
            realm.Write(() =>
            {
                realm.Add(new SendMessage()
                {
                    SenderName = senderName,
                    TextMessage = message,
                    TimeStamp = DateTime.Now.ToString()
                });
            });
        }

        private void InsertReceiveMessageIntoDB(string message, string receiverName)
        {
            var realm = RealmProvider.RealmInstance;
            realm.Write(() =>
            {
                realm.Add(new ReceiveMessage()
                {
                    ReceiverName = receiverName,
                    TextMessage = message,
                    TimeStamp = DateTime.Now.ToString()
                });
            });
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            InsertSendMessageIntoDB(TextArea.Text, "");
            TextArea.Text = String.Empty;
        }
    }



}