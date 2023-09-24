using Realms;
using System;
using MongoDB.Bson;

namespace AplicatiePractica.DB
{
    
    public static class RealmProvider
    {
        public static RealmConfiguration RealmConfig
        {
            get
            {
                return new RealmConfiguration
                {
                    SchemaVersion = 200
                };
            }
        }

        public static Realm RealmInstance
        {
            get
            {
                return Realm.GetInstance(RealmConfig);
            }
        }



    }
}
