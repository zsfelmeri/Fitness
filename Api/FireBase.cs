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

        public async Task<List<Ticket>> GetAllTicket()
        {
            FirebaseResponse response = await client.GetTaskAsync("SeasonTicketTypes");
            Dictionary<string, TicketNeeded> dict = new Dictionary<string, TicketNeeded>();
            dict = JsonConvert.DeserializeObject<Dictionary<string, TicketNeeded>>(response.Body);

            List<Ticket> tickets = new List<Ticket>();
            if(dict != null && dict.Count !=0)
            {
                foreach(var elem in dict)
                {
                    Ticket ticket = new Ticket
                    {
                        id = elem.Key,
                        deleted = elem.Value.deleted,
                        denomination = elem.Value.denomination,
                        fromHour = elem.Value.fromHour,
                        gymId = elem.Value.gymId,
                        numberOfValidDays = elem.Value.numberOfValidDays,
                        numberOfValidEntry = elem.Value.numberOfValidEntry,
                        price = elem.Value.price,
                        toHour = elem.Value.toHour,
                        usageForDay = elem.Value.usageForDay
                    };
                    tickets.Add(ticket);
                }
            }
            return tickets;

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

        public async Task<Ticket> GetTicketById(string id)
        {
            FirebaseResponse response = await client.GetTaskAsync($"SeasonTicketTypes/{id}");
            Ticket ticket = JsonConvert.DeserializeObject<Ticket>(response.Body);
            ticket.id = id;

            return ticket;
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

        public async void UpdateTicket(Ticket ticket)
        {
            TicketNeeded ticketNeeded = new TicketNeeded
            {
                denomination = ticket.denomination,
                gymId= ticket.gymId,
                deleted = ticket.deleted,
                fromHour = ticket.fromHour,
                numberOfValidDays = ticket.numberOfValidDays,
                numberOfValidEntry = ticket.numberOfValidEntry,
                price = ticket.price,
                toHour = ticket.toHour,
                usageForDay = ticket.usageForDay,
            };

            await client.UpdateTaskAsync($"SeasonTicketTypes/{ticket.id}", ticketNeeded);
        }

        public async void InsertClient(Client c, ClientTicket ticket, bool isChecked)
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

            await client.PushTaskAsync("Clients", cn);

            if (isChecked)
            {
                ClientTicketNeeded ctn = new ClientTicketNeeded
                {
                    barCode = ticket.barCode,
                    clientId = ticket.clientId,
                    firstUsageDate = ticket.firstUsageDate,
                    gymId = ticket.gymId,
                    numberOfPreviouslyAccess = ticket.numberOfPreviouslyAccess,
                    purchaseDate = ticket.purchaseDate,
                    sellingPrice = ticket.sellingPrice,
                    ticketId = ticket.ticketId,
                    valid = ticket.valid
                };

                await client.PushTaskAsync("ClientTickets", ctn);
            }
        }

        public async void InsertTicket(Ticket ticket )
        {
            TicketNeeded ticketNeeded = new TicketNeeded
            {
                denomination = ticket.denomination,
                gymId = ticket.gymId,
                deleted = ticket.deleted,
                fromHour = ticket.fromHour,
                numberOfValidDays = ticket.numberOfValidDays,
                numberOfValidEntry = ticket.numberOfValidEntry,
                price = ticket.price,
                toHour = ticket.toHour,
                usageForDay = ticket.usageForDay,
            };

            await client.PushTaskAsync($"SeasonTicketTypes", ticketNeeded);

        }

        public async void DeleteClient(string id)
        {
            await client.DeleteTaskAsync($"Clients/{id}");
        }

        public async void DeleteTicket(string id)
        {
            await client.DeleteTaskAsync($"SeasonTicketTypes/{id}");
        }

        public async Task<List<Client>> SearchClient(string criteria)
        {
            List<Client> cls = new List<Client>();
            cls = await GetClients();

            List<Client> obj = new List<Client>();

            if (cls != null && cls.Count != 0)
            {
                foreach (var c in cls)
                {
                    if(c.name.ToLower().Contains(criteria.ToLower()))
                    {
                        obj.Add(c);
                    }
                }
            }

            return obj;
        }

        public async Task<User> LoginUser(string username, string password)
        {
            FirebaseResponse response = await client.GetTaskAsync("Users");
            Dictionary<string, UserNeeded> dict = new Dictionary<string, UserNeeded>();
            dict = JsonConvert.DeserializeObject<Dictionary<string, UserNeeded>>(response.Body);

            User user = new User();
            if (dict != null && dict.Count > 0) 
            {
                foreach(var u in dict)
                {
                    if(u.Value.username == username && u.Value.password == password)
                    {
                        user.id = u.Key;
                        user.address = u.Value.address;
                        user.name = u.Value.name;
                        user.password = u.Value.password;
                        user.username = u.Value.username;
                        user.role = u.Value.role;
                        user.phoneNumber = u.Value.phoneNumber;
                        break;
                    }
                }
            }

            return user;
        }

        public async Task<List<Employee>> SearchEmployee(string criteria)
        {
            FirebaseResponse response = await client.GetTaskAsync("Employees");
            Dictionary<string, EmployeeNeeded> emp = new Dictionary<string, EmployeeNeeded>();
            emp = JsonConvert.DeserializeObject<Dictionary<string, EmployeeNeeded>>(response.Body);

            List<Employee> empList = new List<Employee>();
            if(emp != null && emp.Count != 0)
            {
                foreach(var e in emp)
                {
                    if (e.Value.name.ToLower().Contains(criteria.ToLower()))
                    {
                        empList.Add(new Employee
                        {
                            id = e.Key,
                            name = e.Value.name,
                            address = e.Value.address,
                            personalIdentity = e.Value.personalIdentity,
                            mobile = e.Value.mobile
                        });
                    }
                }
            }

            return empList;
        }
    }
}
