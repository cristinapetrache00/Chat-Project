using Realms;
using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace AplicatiePractica.DataModels
{
    public class SendMessage : RealmObject
    {
        public string SenderName { get; set; }
        public string TimeStamp { get; set; }
        public string TextMessage { get; set; }
    }

    public class ReceiveMessage : RealmObject
    {
        public string ReceiverName { get; set; }
        public string TimeStamp { get; set; }
        public string TextMessage { get; set; }
    }
}
