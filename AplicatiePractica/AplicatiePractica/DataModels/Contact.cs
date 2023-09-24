using System;
using System.Collections.Generic;
using System.Text;
using Realms;
using MongoDB.Bson;



namespace AplicatiePractica.DataModels
{
    public class Contact : RealmObject
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}

