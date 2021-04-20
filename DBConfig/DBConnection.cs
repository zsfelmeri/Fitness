using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fitness.DBConfig
{
    public class DBConnection : IDBConnection
    {
        IFirebaseClient Client { get; }

        public DBConnection()
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "YesRsuYLstRwO0nWwMxQVvy95qvVlAX6O8TtNckY",
                BasePath = "https://fitnessdb-880d1-default-rtdb.firebaseio.com/"
            };

            this.Client = new FirebaseClient(config);

            if(Client == null)
            {
                
            }
        }
    }
}
