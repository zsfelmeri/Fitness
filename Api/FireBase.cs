using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Fitness.Data;

namespace Fitness.Api
{
    public class FireBase
    {
        private IFirebaseConfig config = new FirebaseConfig
        {
            BasePath = "https://fitnessdb-880d1-default-rtdb.firebaseio.com/",
            AuthSecret = "YesRsuYLstRwO0nWwMxQVvy95qvVlAX6O8TtNckY"
        };
        private IFirebaseClient client;

        

        public FireBase()
        {
            client = new FireSharp.FirebaseClient(config);
            if(client!=null)
            {
                Console.WriteLine("Succsess Firebase connection");
            }
            else
            {
                Console.WriteLine("Not Succsess Firebase connection");
            }
           
        }
        
        public async Task<List<Client>> GetClients(string table)
        {
            FirebaseResponse response = await client.GetTaskAsync(table);
            return response.ResultAs<List<Client>>();
        }

        public async Task<Clientid> GetClientById(string id)
        {
            FirebaseResponse response = await client.GetTaskAsync($"Clients/{id}");
            return response.ResultAs<Clientid>();
        }
    }
}
