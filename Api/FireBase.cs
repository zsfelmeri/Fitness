using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Fitness.Data;
using Newtonsoft.Json;

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
        
        public async Task<List<Client>> GetClients()
        {
            FirebaseResponse response = await client.GetTaskAsync("Clients");
            Dictionary<string, ClientNeeded> dict = new Dictionary<string, ClientNeeded>();
            dict = JsonConvert.DeserializeObject<Dictionary<string, ClientNeeded>>(response.Body);

            List<Client> cls = new List<Client>();
            if (dict != null && dict.Count != 0)
            {
                foreach (var c in dict)
                {
                    Client cc = new Client
                    {
                        id = c.Key,
                        address = c.Value.address,
                        barCode = c.Value.barCode,
                        email = c.Value.email,
                        comments = c.Value.comments,
                        insertedDate = c.Value.insertedDate,
                        isDeleted = c.Value.isDeleted,
                        name = c.Value.name,
                        personalIdentity = c.Value.personalIdentity,
                        photo = c.Value.photo,
                        telefon = c.Value.telefon
                    };
                    cls.Add(cc);
                }
            }

            return cls;
        }

        public async Task<Client> GetClientById(string id)
        {
            FirebaseResponse response = await client.GetTaskAsync($"Clients/{id}");
            Client c = JsonConvert.DeserializeObject<Client>(response.Body);
            c.id = id;

            return c;
        }

        public async void UpdateClient(Client c)
        {
            ClientNeeded clientNeeded = new ClientNeeded
            {
                address = c.address,
                barCode = c.barCode,
                email = c.email,
                comments = c.comments,
                insertedDate = c.insertedDate,
                isDeleted = c.isDeleted,
                name = c.name,
                personalIdentity = c.personalIdentity,
                photo = c.photo,
                telefon = c.telefon
            };

            await client.UpdateTaskAsync($"Clients/{c.id}", clientNeeded);
        }

        public async void InsertClient(Client c)
        {
            ClientNeeded cn = new ClientNeeded
            {
                address = c.address,
                email = c.email,
                barCode = c.barCode,
                isDeleted = c.isDeleted,
                comments = c.comments,
                insertedDate = c.insertedDate,
                name = c.name,
                personalIdentity = c.personalIdentity,
                photo = c.photo,
                telefon = c.telefon
            };

            await client.PushTaskAsync($"Clients", cn);
        }

        public async void DeleteClient(string id)
        {
            await client.DeleteTaskAsync($"Clients/{id}");
        }
    }
}
